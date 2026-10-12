"""Extract the FlexScript in a FlexSim 2019 .fsm file into plain .fs files.

Written in 2026 for this repository, not part of the 2021 thesis.

A .fsm file is a 72-byte header followed by a gzip stream. The stream is a serialized tree in
which each node starts with a flag byte, 7 more flag bytes, a data-type byte, a 32-bit name length
and the NUL-terminated name. String nodes (type 2) then hold a 32-bit length and the text. User
command code sits in string nodes named "code" whose nearest branch node above is the command.
This script scans for such nodes rather than parsing the whole tree, because some node types
(tables, bundles) use layouts I did not decode.

    python tools/extract_flexscript.py model/sbsrs_automodel.fsm src
"""
import re
import struct
import sys
import zlib
from pathlib import Path

HEADER_BYTES = 72


def unpack(fsm):
    return zlib.decompressobj(31).decompress(Path(fsm).read_bytes()[HEADER_BYTES:])


def string_nodes(raw):
    """Yield (offset, name, text, owner) for each string node, owner = nearest branch above."""
    name_ok = re.compile(rb"[^\x00-\x1f]{1,120}")
    owner = ""
    n = len(raw)
    for i in range(n - 14):
        flags, dtype = raw[i], raw[i + 8]
        if not flags & 0x40 or dtype > 8 or raw[i + 4:i + 8] != b"\x00" * 4:
            continue
        nlen = struct.unpack_from("<i", raw, i + 9)[0]
        end = i + 13 + nlen
        if not 2 <= nlen <= 121 or end > n or raw[end - 1] != 0:
            continue
        name = raw[i + 13:end - 1]
        if not name_ok.fullmatch(name):
            continue
        name = name.decode("utf-8", "replace")
        if dtype == 2:
            slen = struct.unpack_from("<i", raw, end)[0]
            if 1 <= slen < 2_000_000 and end + 4 + slen <= n and raw[end + 4 + slen - 1] == 0:
                text = raw[end + 4:end + 4 + slen - 1].decode("utf-8", "replace")
                yield i, name, text, owner
        if flags & 0x80:
            owner = name


def layout(command):
    for folder, pattern in [("layout_A", r"_A\d$"), ("layout_B", r"_B[TR]\d\d$"),
                            ("layout_C", r"_(CF\d\d|C)$")]:
        if re.search(pattern, command):
            return folder
    return "common"


def tidy(text):
    lines = text.replace("\r\n", "\n").replace("\r", "\n").split("\n")
    return "\n".join(line.rstrip() for line in lines).strip() + "\n"


def main(fsm, out):
    out = Path(out)
    count = 0
    for _, name, text, owner in string_nodes(unpack(fsm)):
        if name != "code" or not owner:
            continue
        path = out / "user_commands" / layout(owner) / f"{owner}.fs"
        if path.exists():
            continue
        path.parent.mkdir(parents=True, exist_ok=True)
        path.write_text(tidy(text), encoding="utf-8")
        count += 1
    print(f"wrote {count} user commands to {out / 'user_commands'}")


if __name__ == "__main__":
    main(*sys.argv[1:3])
