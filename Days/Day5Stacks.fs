module Day5Stacks

open System.Collections

//  [M] [H]         [N]
//  [S] [W]         [F]     [W] [V]
//  [J] [J]         [B]     [S] [B] [F]
//  [L] [F] [G]     [C]     [L] [N] [N]
//  [V] [Z] [D]     [P] [W] [G] [F] [Z]
//  [F] [D] [C] [S] [W] [M] [N] [H] [H]
//  [N] [N] [R] [B] [Z] [R] [T] [T] [M]
//  [R] [P] [W] [N] [M] [P] [R] [Q] [L]
//   1   2   3   4   5   6   7   8   9

let stacks =
    [ Stack()
      Stack()
      Stack()
      Stack()
      Stack()
      Stack()
      Stack()
      Stack()
      Stack()
      Stack() ]


stacks.[1].Push('R')
stacks.[1].Push('N')
stacks.[1].Push('F')
stacks.[1].Push('V')
stacks.[1].Push('L')
stacks.[1].Push('J')
stacks.[1].Push('S')
stacks.[1].Push('M')

stacks.[2].Push('P')
stacks.[2].Push('N')
stacks.[2].Push('D')
stacks.[2].Push('Z')
stacks.[2].Push('F')
stacks.[2].Push('J')
stacks.[2].Push('W')
stacks.[2].Push('H')
stacks.[3].Push('W')
stacks.[3].Push('R')
stacks.[3].Push('C')
stacks.[3].Push('D')
stacks.[3].Push('G')
stacks.[4].Push('N')
stacks.[4].Push('B')
stacks.[4].Push('S')

stacks.[5].Push('M')
stacks.[5].Push('Z')
stacks.[5].Push('W')
stacks.[5].Push('P')
stacks.[5].Push('C')
stacks.[5].Push('B')
stacks.[5].Push('F')
stacks.[5].Push('N')

stacks.[6].Push('P')
stacks.[6].Push('R')
stacks.[6].Push('M')
stacks.[6].Push('W')

stacks.[7].Push('R')
stacks.[7].Push('T')
stacks.[7].Push('N')
stacks.[7].Push('G')
stacks.[7].Push('L')
stacks.[7].Push('S')
stacks.[7].Push('W')

stacks.[8].Push('Q')
stacks.[8].Push('T')
stacks.[8].Push('H')
stacks.[8].Push('F')
stacks.[8].Push('N')
stacks.[8].Push('B')
stacks.[8].Push('V')

stacks.[9].Push('L')
stacks.[9].Push('M')
stacks.[9].Push('H')
stacks.[9].Push('Z')
stacks.[9].Push('N')
stacks.[9].Push('F')


let testStacks = [ Stack(); Stack(); Stack(); Stack() ]
testStacks.[1].Push('Z')
testStacks.[1].Push('N')
testStacks.[2].Push('M')
testStacks.[2].Push('C')
testStacks.[2].Push('D')
testStacks.[3].Push('P')
