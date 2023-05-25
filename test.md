# Test Cases

This is a description of the test cases used in this program.

## Test Cases: Single Node Graph (with and without Loop)

`edge-case-1.txt` and `edge-case-2.txt` are both single node graphs to test that the program produces correct output. It should produce a graph with a single node. It is worth noting that this test case resulting in the addition of the block of code in `Graph.cs` that added each node to the `.dot` file (lines 122-128).

`edge-case-1.txt`

```
1
```

`edge-case-2.txt`

```
0
```

## Test Case: Matrix with Excess Columns

`fail-case-1.txt` contains an adjacency matrix in which one of the rows contains an extra column. The presumption made in developing the program was that this was acceptable and that the extra column data would be ignored. This tests to ensure the program behaves accordingly.

`fail-case-1.txt`

```
0	1	0	1
1	0	1	0
0	1	0	0	0
1	0	1	0
```

## Test Case: Matrix with Missing Rows

`fail-case-2.txt` contains an adjacency matrix in which the last row is missing. The presumption made in developing the program was that the program would continue running, assuming that the missing row contained all 0s (i.e., no edge representation). This tests to ensure the program behaves accordingly.

`fail-case-2.txt`

```
0	1	0	1
1	0	1	0
0	1	0	0
```

## Test Case: Matrix with Missing Column

`fail-case-3.txt` contains an adjacency matrix in which one row is missing a column value. The presumption made in developing the program was that the program would continue running, assuming that the missing column contained a 0. This tests to ensure the program behaves accordingly.

`fail-case-3.txt`

```
0	1	0	1
1	0	1	0
0	1	0
1	0	1	0
```

## Test Case: Correct Non-directional Graphs

`adj1.txt` and `adj2.txt` were provided in the assignment and are used here to test "correct" output for a non-directional graph.

## Test Case: Correct Directional Graph

`adj3.txt` and `adj4.txt` were provided in the assignment and are used here to test "correct" output for a directional graph.

## Test Case: Graph with Disconnected Node

`disconnect.txt` features an adjacency matrix in which one node is disconnected from the rest of the graph. The detached node should still appear in the resulting output.

`disconnect.txt`

```
0	1	0	0	0	0
1	0	1	0	1	0
0	0	0	0	0	1
0	0	0	0	0	0
0	0	0	0	1	0
1	0	1	0	1	0
```
