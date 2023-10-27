module Day7

type File = { Name: string; Size: int }

type Directory =
    { Name: string
      Files: File list
      Dirs: Directory list }

let newDir name = { Name = name; Files = []; Dirs = [] }

let backup (cDir: string) : string =
    cDir.Split('/')
    |> fun s -> s.[..s.Length - 1]
    |> String.concat "/"


let parse inputs =

    let root = newDir "Root"

    let rec Next (currentDir: Directory) (input: string list) =
        match input with
        | [] -> currentDir
        | hd :: tl ->
            let splits = hd.Split(' ')

            match splits.[0] with
            | "$" ->
                match splits.[1] with
                | "cd" ->
                    match splits.[2] with
                    | ".." -> Next(backup currentDir.Name) tl
                    | s -> state.directories @ [ (newDir state.name s) ]
                    | _ -> failwith "Failed in cd"
                | "ls" -> Next currentDir tl
                | _ -> failwith "Error in match splits.[1]"
            | "dir" -> currentDir.Dirs @ [ splits.[1] ]
            | n ->
                match System.Int32.Parse n with
                | n ->
                    currentDir.files
                    @ [ { Name = splits.[1]; Size = n } ]

                    Next currentDir tl
                | _ -> failwith "Failed to parse number %A" n

    Next
