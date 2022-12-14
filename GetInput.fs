module GetInput

let GetInputAsLines (dayNumber: int) (isTest: bool) : string list =
    if isTest then
        $".//Inputs//testDay{(string dayNumber)}.txt"
        |> System.IO.File.ReadAllLines
        |> Array.toList

    else
        $".//Inputs//Day{(string dayNumber)}.txt"
        |> System.IO.File.ReadAllLines
        |> Array.toList



let GetInputAsString (dayNumber: int) (isTest: bool) : string =
    if isTest then
        $".//Inputs//testDay{(string dayNumber)}.txt"
        |> System.IO.File.ReadAllText
    else
        $".//Inputs//Day{(string dayNumber)}.txt"
        |> System.IO.File.ReadAllText
