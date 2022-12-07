module GetInput

let GetInput (dayNumber: int) (isTest: bool) : string list =
    if isTest then
        $".//inputs//testDay{(string dayNumber)}.txt"
        |> System.IO.File.ReadAllLines
        |> Array.toList

    else
        $".//inputs//Day{(string dayNumber)}.txt"
        |> System.IO.File.ReadAllLines
        |> Array.toList
