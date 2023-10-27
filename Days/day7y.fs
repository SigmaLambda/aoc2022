module day7y

open System


type File = { name: string; size: int }

type Directory = { name: string; totalSize: int }

type Item =
    | File of File
    | Dir of Directory

let inputs =
    System.IO.File.ReadAllLines "inputDay7.txt"
    |> Array.toList

let nextDir (current: string) (next: string) : string =
    if current = "" then
        next
    else if current = "/" then
        current + next
    else
        current + "/" + next


let join (s1: string) (s2: string) : string = s1 + "/" + s2


let backupDir (current: string) : string =
    let res =
        current.Split('/')
        |> Array.filter (fun x -> x <> "")
        |> Array.rev
        |> Array.tail
        |> Array.rev
        |> Array.fold join ""

    if res = "" then "/" else res


let createItem (pwd: string) (line: string) =
    let part = line.Split(" ")
    let prefix = if pwd = "/" then pwd else pwd + "/"

    match part.[0] with
    | "dir" ->
        Dir
            { name = prefix + part.[1]
              totalSize = 0 }
    | _ ->
        File
            { name = prefix + part.[1]
              size = int part.[0] }


let rec divide pred ls firstpart secondpart =
    match ls with
    | [] -> (List.rev firstpart), secondpart
    | hd :: tl ->
        match (pred hd) with
        | true -> (List.rev firstpart), secondpart
        | false -> divide pred tl (hd :: firstpart) tl



let startsWith (s: string) = s.StartsWith("$")


let rec GetStructure (inputs: string list) (current: string) (counter: int) (currentItems: Item List) =

    printf "%d current: %s\t" counter current

    match inputs with
    | [] -> currentItems
    | hd :: tl ->
        printf "hd::tl \t"
        let splits = hd.Split(" ")

        match splits.[0] with
        | "$" ->
            printf "In $ \t"

            match splits.[1] with
            | "cd" ->
                printf "In CD \t"

                match splits.[2] with
                | ".." ->
                    printfn "Backing up"
                    GetStructure tl (backupDir current) (counter + 1) currentItems
                | _ ->
                    printfn "Adding %s" splits.[2]

                    GetStructure tl (nextDir current splits.[2]) (counter + 1) currentItems
            | "ls" ->
                printfn "In ls"

                let newCandidates, restOfCommands = divide startsWith tl [] []


                let newItems =
                    newCandidates
                    |> List.map (fun c -> createItem current c)


                let totalsize =
                    newItems
                    |> List.choose (fun x ->
                        match x with
                        | File f -> Some f
                        | _ -> None)
                    |> List.map (fun x -> x.size)
                    |> List.fold (+) 0

                printfn "Current: %s\t %d" current totalsize
                printfn "newItems %A" newItems

                let combinedItems = List.append currentItems newItems

                GetStructure restOfCommands current (counter + 1) combinedItems
            | _ ->
                printfn "In cd-level misc"
                GetStructure tl current (counter + 1) currentItems
        | _ ->
            printfn "In $ misc"
            GetStructure tl current (counter + 1) currentItems

//then filter all that starts with dirname. Add those together and add to totsize.
let totSize (startswith:string) (items:Item list) =
    items
    |> List.filter (fun i -> startswith.StartsWith(i.name) ) 
    |> List.choose (fun i ->
        match i with
        | File f -> Some f
        | _ -> None)
    |> List.map (fun f -> f.size)
    |> List.fold (+) 0


let getDirs items =
    let dirs =
        items //filter all directories x
        |> List.choose (fun x ->
            match x with
            | Dir d -> Some d
            | _ -> None)

    dirs |> printfn "GetDirs: %A" |> ignore

    items
    |> List.map( fun (i:items) -> 
        let size = totsize d.name items
        { d with d.totalSize = size }
        )
    dirs

let items = GetStructure inputs "" 0 List.Empty
getDirs items |> printfn "GetDirs: %A" |> ignore
