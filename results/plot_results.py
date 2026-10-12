"""Redraw the fleet-size results (thesis tables 6-6 to 6-8, figures 6-2 to 6-5) in English.

Each value is the mean of 20 replications of the AL1 layout. The thesis reported means only,
so no confidence intervals are drawn.
"""
from pathlib import Path

import matplotlib.pyplot as plt
import pandas as pd

HERE = Path(__file__).parent
df = pd.read_csv(HERE / "fleet_size_experiment.csv")
x = df["shuttles_per_aisle"]

fig, (left, right) = plt.subplots(1, 2, figsize=(10, 4.3))

left.bar(x, df["outbound_totes"], width=1.2, color="#2a78d6")
for xi, yi in zip(x, df["outbound_totes"]):
    left.text(xi, yi + 20, f"{yi:,}", ha="center", fontsize=9)
left.set_ylim(0, 1700)
left.set_xticks(x)
left.set_xlabel("Shuttles per aisle")
left.set_ylabel("Outbound totes per run")
left.set_title("Outbound throughput (range 3%)", fontsize=11)

series = [
    ("transfer_lift_util_pct", "Tier-transfer lift", "#d1495b"),
    ("outbound_lift_util_pct", "Outbound lift", "#e0702b"),
    ("inbound_lift_util_pct", "Inbound lift", "#8d6cab"),
    ("shuttle_util_pct", "Shuttle", "#2a78d6"),
]
for col, label, color in series:
    right.plot(x, df[col], marker="o", label=label, color=color)
right.set_xticks(x)
right.set_ylim(0, 100)
right.set_xlabel("Shuttles per aisle")
right.set_ylabel("Mean utilization (%)")
right.set_title("Equipment utilization", fontsize=11)
right.legend(fontsize=8, frameon=False, ncol=2, loc="upper center", bbox_to_anchor=(0.5, -0.2))

for ax in (left, right):
    ax.spines[["top", "right"]].set_visible(False)
fig.tight_layout()
fig.savefig(HERE / "fleet_size_experiment.png", dpi=150)
print("saved fleet_size_experiment.png")
