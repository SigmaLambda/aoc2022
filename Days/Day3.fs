module Day3


let findDuplicate ys x = Array.tryFind (fun y -> x = y) ys

let parseInput (line: string) =
    let charArr = line.ToCharArray()
    let firstPart = charArr.[..((line.Length / 2) - 1)]
    let secondPart = charArr.[((line.Length / 2))..]

    Array.choose (findDuplicate secondPart) firstPart
    |> fun a -> a.[0]


let map =
    Map.ofList (List.zip ([ 'a' .. 'z' ] @ [ 'A' .. 'Z' ]) [ 1 .. 52 ])

let score (map: Map<char, int>) (key: char) = map.TryFind key

let Day3Run1 (input: string list) =
    input
    |> List.map parseInput
    |> List.choose (score map)
    |> List.fold (+) 0
    |> printfn "Total score: %d"


//Part2
let findCommon (threeLines: char list list) =
    let super =
        seq {
            yield Set.ofList threeLines.[0]
            yield Set.ofList threeLines.[1]
            yield Set.ofList threeLines.[2]
        }

    Set.intersectMany super
    |> List.ofSeq
    |> fun x -> x.[0]


let rec score3 acc input =
    match input with
    | [] -> acc
    | hd :: tl ->
        let score =
            input |> List.take 3 |> findCommon |> score map

        score3 (score :: acc) input.[3..]



let Day3Run2 (input: string list) =
    input
    |> List.map (fun x -> x.ToCharArray() |> Array.toList)
    |> score3 []
    |> List.choose id
    |> List.fold (+) 0
    |> printfn "Total score: %d"

//Finished 22/12/12 19:29
