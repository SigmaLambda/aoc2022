module GetInput

let GetInput (dayNumber: int) (isTest: bool) : string list =
    if isTest then
        $".//Inputs//testDay{(string dayNumber)}.txt"
        |> System.IO.File.ReadAllLines
        |> Array.toList

    else
        $".//Inputs//Day{(string dayNumber)}.txt"
        |> System.IO.File.ReadAllLines
        |> Array.toList
