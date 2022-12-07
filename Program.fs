// For more information see https://aka.ms/fsharp-console-apps
open GetInput
open Day1

printfn "Hello from F#"


GetInput 1 true |> Day1Run1
GetInput 1 false |> Day1Run1
GetInput 1 false |> Day1Run2
