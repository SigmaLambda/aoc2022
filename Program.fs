// For more information see https://aka.ms/fsharp-console-apps
open GetInput

printfn "Hello from F#"

//GetInput 6 true |> Day6.Run1Test
GetInputAsString 6 false |> Day6.Run1
GetInputAsString 6 false |> Day6.Run2

//GetInputAsLines 5 true |> Day5.Run1Test
//GetInputAsLines 5 false |> Day5.Run1 //cannot run at same time part 2.
//GetInputAsLines 5 false |> Day5.Run2

//GetInputAsLines 4 true |> Day4.Run1
//GetInputAsLines 4 false |> Day4.Run1
//GetInputAsLines 4 false |> Day4.Run2

//GetInputAsLines 3 true |> Day3.Day3Run1
//GetInputAsLines 3 false |> Day3.Day3Run1
//GetInputAsLines 3 false |> Day3.Day3Run2

//GetInputAsLines 2 true |> Day2.Day2Run1
//GetInputAsLines 2 false |> Day2.Day2Run1
//GetInputAsLines 2 false |> Day2.Day2Run2

//GetInputAsLines 1 true |> Day1.Day1Run1
//GetInputAsLines 1 false |> Day1.Day1Run1
//GetInputAsLines 1 false |> Day1.Day1Run2
