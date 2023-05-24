# CPSC 5031 Homework 6 (5 pts)

## Visualizing Graphs

Let’s write more code!

Remember this image?

![Graph Image]()

This was generated using a toolkit called GraphViz (http://www.graphviz.org/). It’s a very handy tool to have in your personal toolkit. You can download/install it from these directions: http://www.graphviz.org/download/

## Assignment

Write a program that can take an adjacency matrix file and generate a GraphViz “dot file”. Run the dot files through `dot` (one of the GraphViz command line tools) and generate a PNG file.

Example command line:

```
   dot -Tpng myfile.dot -o myfile.png
```

## Adjacency File Format

The adjacency files are matrices of 1s and 0s, separated by tab (\t) characters. Here’s an example:

```
0   0   1   1
0   0   1   1
1   1   0   0
1   1   0   0
```

### OH, ONE LITTLE DETAIL:

**You must determine if the adjacency file could be a digraph.** If it is, use the `digraph` command in your dot file. Otherwise, use `graph`. Remember, unless it’s a directed graph, there shouldn’t be two edges connecting the same two vertices.

## What you need to turn in:

1. Your code. (I don’t need the dot files.)
2. An explanation of the test cases you used.
3. The images generated for each adjacency matrix included in the homework.
