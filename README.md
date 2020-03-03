# Breakout

### Collision layers and mask

| Scene    | Layer  | Mask    |
|:---------|:-------|:--------|
| Player   | 1      | 2, 3, 4 |
| Ball     | 3      | 1, 4    |
| Bricks   | 4      | 3, 4    |
| Powerups | 2      | 1       |
| Walls    | 4      | 4       |

### Dependencies

+ Visual Studio Build Tools: https://visualstudio.microsoft.com/downloads/?q=build+tools
+ Mono SDK: https://www.mono-project.com/download/stable/
+ .NET Framework 4.7 (Needs to be exact): https://www.microsoft.com/en-us/download/details.aspx?id=55170
