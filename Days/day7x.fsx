module Day7

type File = { Name: string; Size: int }

type Directory =
    { Name: string
      Files: Map<string, File>
      Dirs: Map<string, Directory> }

type item =
    | Directory
    | File

let addFile filename size path root =
    Map.add (path + "/" + filename) { Name = filename; Size = size } root

let addDir dirName path root =
    Map.add
        (path + "/" + dirName)
        { Name = dirName
          Files = Map.empty
          Dirs = Map.empty }
        root

let inputs =
    System.IO.File.ReadAllLines "./Inputs/testDay7.txt"
    |> Array.toList

let backup path = 
    let splits = path.Split("/")
    let allbutLast = splits.[.. (splits.Length - 1) ]
    

let rec loop (inputs: string list) path system =

    match inputs with
    | [] -> system
    | hd :: tl ->
        let splits = hd.Split(" ")

        match splits.[0] with
        | "$" ->
            match splits.[1] with
            | "cd" ->
                if splits.[2] = ".." then
                    loop tl (backup path) system
                else
                    let newSystem = addDir splits.[2] path system
                    let newPath = path + "/" + splits.[2]
                    loop tl newPath newSystem
            | "ls" -> loop tl path system

            | _ -> failwith "Error"
        | _ ->
            printfn "somefiles" |> ignore
            loop tl path system
