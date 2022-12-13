module Day5

open Day5Stacks
open System.Collections

type Order = { Count: int; From: int; To: int }

let parseToOrders (input: string list) =
    input
    |> List.map (fun x -> x.Split(' '))
    |> List.map (fun (x: string array) ->
        { Count = int x.[1]
          From = int x.[3]
          To = int x.[5] })

let move (stacks: Stack list) (order: Order) =
    for _ in 1 .. order.Count do
        stacks.[order.From].Pop()
        |> stacks.[order.To].Push



let Run1Test (input: string list) =
    input
    |> parseToOrders
    |> List.map (move testStacks)
    |> ignore

    testStacks.[1..]
    |> List.map (fun x -> x.Pop())
    |> List.map string
    |> List.fold (+) ""
    |> printfn "Top boxes are: %s"


let Run1 (input: string list) =
    input
    |> parseToOrders
    |> List.map (move stacks)
    |> ignore

    stacks.[1..]
    |> List.map (fun x -> x.Pop())
    |> List.map string
    |> List.fold (+) ""
    |> printfn "Top boxes are: %s"

//Part two

let move9001 (stacks: Stack list) (order: Order) =
    let tempStack = Stack()

    for _ in 1 .. order.Count do
        tempStack.Push(stacks.[order.From].Pop())

    for _ in 1 .. order.Count do
        stacks.[order.To].Push(tempStack.Pop())

let Run2 (input: string list) =
    input
    |> parseToOrders
    |> List.map (move9001 stacks)
    |> ignore

    stacks.[1..]
    |> List.map (fun x -> x.Pop())
    |> List.map string
    |> List.fold (+) ""
    |> printfn "Top boxes are: %s"
