import sys
import math

# Auto-generated code below aims at helping you parse
# the standard input according to the problem statement.
str_input = """1 2 3 4 5 6 7 8 9
4 5 6 7 8 9 1 2 3
7 8 9 1 2 3 4 5 6
9 1 2 3 4 5 6 7 8
3 4 5 6 7 8 9 1 2
6 7 8 9 1 2 3 4 5
8 9 1 2 3 4 5 6 7
2 3 4 5 6 7 8 9 1
5 6 7 8 9 1 2 3 4"""

row = []

def input():
    return str_input

result = 0
rows = []

#for i in range(9):
for row in input().split("\n"):
    r = []
    for cell in row.split():
        r.append(int(cell))
    rows.append(r)
print(rows[1][2])
print(rows[2][2])
#[][]
# Write an answer using print
# To debug: print("Debug messages...", file=sys.stderr, flush=True)