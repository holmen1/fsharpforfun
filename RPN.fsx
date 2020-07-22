// Mats RPN

let reqstring = "4 3 + 2 *"
let reqlist = reqstring.Split(" ")

let words0 = (fun (line : string) -> Seq.toList (line.Split ' '))

let words = (fun (str:string) ->
    str.Split ' '
    |> Seq.toList)

// error FS0072: Lookup on object of indeterminate type based on information prior to this program point
let words2 str:string =
    (str.Split ' ')
    |> Seq.toList

let l1 = words reqstring
// Display our results in a for-loop.
for value in l1 do
    printfn "%A" value


type RPN = string -> int list
//let rec RPN stringl =
