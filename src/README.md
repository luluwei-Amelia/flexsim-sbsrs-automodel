# FlexScript source

Extracted from `model/sbsrs_automodel.fsm` so the code can be read without FlexSim. The model file
is the version that runs; these files are a copy for reading. Comments are in Chinese.

| Folder | Files | Content |
|---|---|---|
| `user_commands/common/` | 34 | Commands shared by all layouts: racks, buffers, lifts, shuttles, picking stations, sources, groups, lists |
| `user_commands/layout_A/` | 12 | Same end, same tier (AL/AR 1-3) |
| `user_commands/layout_B/` | 72 | Same end, two tiers (BT11-BT33 and BR11-BR33) |
| `user_commands/layout_C/` | 40 | Opposite ends (CF11-CF33) |
| `gui/` | 3 | Button scripts: the build button that dispatches to a layout, table import |
| `processflow/` | 5 | Custom code in ProcessFlow activities: shuttle list, task arrivals, inventory update |
| `statistics/` | 3 | Calculated columns for utilization, mean cycle time and mean capacity |

Each layout has four commands: `main_<layout>` calls the others in order, `conveyor_<layout>` builds
the conveyors, `ruku_<layout>` (inbound) connects the inbound side and `PickStation_<layout>` places the
picking stations. `main_A1` is a good place to start:

```c
lib(); Rack(); Queue(); Elevator(); conveyor_A1(); Shuttle(); SetShuttle(); ruku_A1();
SetRack(); SetRackList(); SetSource(); SetQueueIn(); CreateGroup(); chuku(); SetChuku();
OriginalSource_2(); SetOriginalSource_2(); PickStation_A1(); SetPickStation(); CreateGroup2();
```

There are 30 layout-specific command sets (3 in A, 18 in B, 9 in C). The other 30 of the 60
configurations are their mirror images (left end and right end): the build button
(`gui/build_model_button.fs`) builds the same model and turns the camera by 180 degrees, since a
mirrored layout behaves the same in simulation.

`lib()` loads the object library `model/lib19.fsl` from a fixed path. Change the path in
`user_commands/common/lib.fs` (or the same command in the model) before building.
