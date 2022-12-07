module Day1


type Inventory =
    { id: int
      items: int list
      total: int }

let rec createInventory
    (inventories: Inventory list)
    (id: int)
    (acc: int list)
    (rawData: string list)
    : Inventory list =
    match rawData with
    | [] -> inventories
    | hd :: tl ->
        if hd = "" then
            let newInventory =
                { id = id + 1
                  items = acc
                  total = List.fold (+) 0 acc }

            createInventory (newInventory :: inventories) (id + 1) [] tl
        else
            createInventory inventories id (((int) hd) :: acc) tl


let findBiggestInventory (input: string list) : Inventory =
    let inventories = createInventory [] 0 [] input
    List.maxBy (fun x -> x.total) inventories

let Day1Run1 input =
    let biggest = findBiggestInventory input
    printfn "Biggest total: %d\t of elf number: %d" biggest.total biggest.id

let Day1Run2 input =
    createInventory [] 0 [] input
    |> List.sortByDescending (fun item -> item.total)
    |> List.take 3
    |> List.map (fun i -> i.total)
    |> List.fold (+) 0
    |> fun x -> printfn "Top three total: %d" x
