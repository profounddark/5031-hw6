# Test Cases

This is a description of the test cases used in this program.

## Test Cases: Single Node Graph (with and without Loop)

`edge-case-1.txt` and `edge-case-2.txt` are both single node graphs to test that the program produces correct output. It should produce a graph with a single node.

## Test Case: Matrix with Excess Columns

`fail-case-1.txt` contains an adjacency matrix in which one of the rows contains an extra column. The presumption made in developing the program was that this was acceptable and that the extra column data would be ignored. This tests that to ensure it behaves accordingly.

## Test Case: Matrix with Missing Rows

`fail-case-2.txt` contains an adjacency matrix in which the last row is missing. The presumption made in developing the program was that the program would continue, assuming that the missing row contained all 0s (i.e., no edge representation). This tests to ensure it behaves accordingly.

## Test Case: Matrix with Missing Column

`fail-case-3.txt` contains an adjacency matrix in which one row is missing a column value. The presumption made in developing
