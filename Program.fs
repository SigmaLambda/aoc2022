// For more information see https://aka.ms/fsharp-console-apps
open GetInput

printfn "Hello from F#"

//GetInput 1 true |> Day1.Day1Run1
//GetInput 1 false |> Day1.Day1Run1
//GetInput 1 false |> Day1.Day1Run2

//GetInput 2 true |> Day2.Day2Run1
//GetInput 2 false |> Day2.Day2Run1
//GetInput 2 false |> Day2.Day2Run2

//GetInput 3 true |> Day3.Day3Run1
//GetInput 3 false |> Day3.Day3Run1
//GetInput 3 false |> Day3.Day3Run2

//GetInput 4 true |> Day4.Run1
//GetInput 4 false |> Day4.Run1
//GetInput 4 false |> Day4.Run2

GetInput 5 true |> Day5.Run1Test
//GetInput 5 false |> Day5.Run1 //cannot run before part 2.
GetInput 5 false |> Day5.Run2
