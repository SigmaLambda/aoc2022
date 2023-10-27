module utils

//The ifSomeDoSome function
let (||>) x f =
    match x with
    | Some x -> Some f x
    | none -> None
