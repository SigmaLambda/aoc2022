module Day6


let rec findStartChar (totCount: int) (distinctNum: int) (cs: char list) : int =
    match cs with
    | [] -> -1
    | hd :: tl ->
        let distinctChars =
            cs
            |> List.take distinctNum
            |> List.distinct
            |> List.length

        if distinctChars = distinctNum then
            totCount + distinctNum
        else
            findStartChar (totCount + 1) distinctNum tl


let Run1 (input: string) =
    input
    |> fun s -> s.ToCharArray()
    |> Array.toList
    |> findStartChar 0 4
    |> printfn "First start char at: %d"


let Run2 (input: string) =
    input
    |> fun s -> s.ToCharArray()
    |> Array.toList
    |> findStartChar 0 14
    |> printfn "First start message at: %d"
