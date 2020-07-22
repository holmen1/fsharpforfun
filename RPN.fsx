// Mats RPN

let reqstring = "4 3 + 2 *"

let words0 = (fun (line : string) -> Seq.toList (line.Split ' '))

let words = (fun (str:string) ->
    str.Split ' '
    |> Seq.toList)

// error FS0072: Lookup on object of indeterminate type based on information prior to this program point
let words2 str =
    (str.Split ' ')
    |> Seq.toList

let l1 = words reqstring



type Stack = StackContents of int list

// ==============================================
// Stack primitives
// ==============================================

/// Push a value on the stack
let push x (StackContents contents) =   
    StackContents (x::contents)

/// Pop a value from the stack and return it 
/// and the new stack as a tuple
let pop (StackContents contents) = 
    match contents with 
    | top::rest -> 
        let newStack = StackContents rest
        (top,newStack)
    | [] -> 
        failwith "Stack underflow"

// Constants
// -------------------------------
let EMPTY = StackContents []
let START  = EMPTY


//type RPN = string -> int list
let rec RPN stringl stack =
    match stringl with
    | [] -> stack
    | x::tail -> RPN tail (push x stack)


// Test
let stack0 = EMPTY
let l0 = [1;2;3;4]
let s0 = RPN l0 stack0
