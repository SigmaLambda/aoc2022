module Day2


type Hand =
    | Rock
    | Paper
    | Scissor

let scoreHand hand =
    match hand with
    | Hand.Rock -> 1
    | Hand.Paper -> 2
    | Hand.Scissor -> 3

let parseHand hand =
    match hand with
    | "A" -> Hand.Rock
    | "B" -> Hand.Paper
    | "C" -> Hand.Scissor
    | "X" -> Hand.Rock
    | "Y" -> Hand.Paper
    | "Z" -> Hand.Scissor
    | _ -> failwith "Error in parsehand!"


let scoreOutCome (elfHand, myHand) =
    match elfHand, myHand with
    | Rock, Rock -> 3 + scoreHand Rock
    | Rock, Paper -> 6 + scoreHand Paper
    | Rock, Scissor -> 0 + scoreHand Scissor

    | Paper, Rock -> 0 + scoreHand Rock
    | Paper, Paper -> 3 + scoreHand Paper
    | Paper, Scissor -> 6 + scoreHand Scissor

    | Scissor, Rock -> 6 + scoreHand Rock
    | Scissor, Paper -> 0 + scoreHand Paper
    | Scissor, Scissor -> 3 + scoreHand Scissor


let parseline (line: string) =
    let split = line.Split(' ')
    split.[0], split.[1]


let Day2Run1 (input: string list) =
    input
    |> List.map parseline
    |> List.map (fun (a, x) -> parseHand a, parseHand x)
    |> List.map scoreOutCome
    |> List.fold (+) 0
    |> fun x -> printfn "Total score: %d" x


//X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win

let winParser (elfHand, myHand) =
    match (elfHand, myHand) with
    | "A", "X" -> Hand.Scissor //Rock, loose
    | "A", "Y" -> Hand.Rock //Rock, draw
    | "A", "Z" -> Hand.Paper //Rock, win

    | "B", "X" -> Hand.Rock //Paper, loose
    | "B", "Y" -> Hand.Paper //Paper, draw
    | "B", "Z" -> Hand.Scissor //Paper, win

    | "C", "X" -> Hand.Paper //Scissor, loose
    | "C", "Y" -> Hand.Scissor //Scissor, draw
    | "C", "Z" -> Hand.Rock //Scissor, win
    | _ -> failwith "Error in parsehand!"


let Day2Run2 (input: string list) =
    input
    |> List.map parseline
    |> List.map (fun (a, x) -> parseHand a, winParser (a, x))
    |> List.map scoreOutCome
    |> List.fold (+) 0
    |> fun x -> printfn "Total score: %d" x
