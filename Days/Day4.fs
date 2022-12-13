module Day4

let parseInput (line: string) =
    //4-50,49-50
    let split = line.Split(',', '-')
    let start1 = int (split.[0])
    let stop1 = int (split.[1])
    let start2 = int (split.[2])
    let stop2 = int (split.[3])

    Set.ofSeq [ start1 .. stop1 ], Set.ofSeq [ start2 .. stop2 ]



let Run1 (input: string list) =
    input
    |> List.map parseInput
    |> List.filter (fun (s1, s2) -> Set.isSubset s1 s2 || Set.isSubset s2 s1)
    |> List.length
    |> fun x -> printfn "%d fully contained" x

//Part2

let Run2 (input: string list) =
    input
    |> List.map parseInput
    |> List.filter (fun (s1, s2) ->
        Set.intersect s1 s2 |> Set.count > 0
        || Set.intersect s2 s1 |> Set.count > 0)
    |> List.length
    |> fun x -> printfn "%d partially overlapped" x

//Start 2022/12/12 19:30
//Finished 2022/12/20:50
