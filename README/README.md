# GridCreator v1.0.0 (updated April 24th, 2018)
GridCreator will arrange an unordered list of two-dimensional points into proper rows and columns.


# Assumptions

 - While the provided points do not have to appear in any particular
   order, they must be part of an NxN grid (same number of rows as columns).
 - Points must be evenly spaced on the NxN grid.
 - All points on the grid must be included, with no extraneous points. 
*Example: a 4x4 grid should have exactly 16 points listed in the input    file*
 - Since the minimum grid size is 2x2, at least four points must be provided.
 - The input file should contain each point on a separate line with the X and Y coordinates separated by a comma. No other lines, whitespace, or data should be included in the file. *Example:*
```
14.0,10.0<CR><LF>
10.0,10.0<CR><LF>
12.0,10.0<CR><LF>
10.0,12.0<CR><LF>
10.0,14.0<CR><LF>
12.0,12.0<CR><LF>
14.0,12.0<CR><LF>
14.0,14.0<CR><LF>
12.0,14.0<CR><LF>
```

# Usage
To use GridCreator, invoke the executable file ***GridCreator.exe*** (located in ```\GridCreator\bin\Release```) with an argument containing the input file path.

*Example execution:* 
>$ GridCreator.exe ../../../InputFiles/grid_input.txt

*Example output:*
```
Row 0: 10,14 - 12,14 - 14,14
Row 1: 10,12 - 12,12 - 14,12
Row 2: 10,10 - 12,10 - 14,10
Column 0: 10,14 - 10,12 - 10,10
Column 1: 12,14 - 12,12 - 12,10
Column 2: 14,14 - 14,12 - 14,10
Alpha=0 degrees
```
