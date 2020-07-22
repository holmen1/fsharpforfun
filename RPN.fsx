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
let rec RPN0 stringl stack =
    match stringl with
    | [] -> stack
    | x::tail -> RPN0 tail (push x stack)


// Test 0
let stack0 = EMPTY
let l0 = [1;2;3;4]
let s0 = RPN0 l0 stack0

let isOperator str =
    List.contains str ["+"; "-"; "*"; "/"]

let rec RPN1 stringl stack =
    match stringl with
    | [] -> stack
    | (notO & head) :: tail when not (isOperator notO) -> RPN1 tail (push (int head) stack)

// Test 1
let stack0 = EMPTY
let l1 = ["1";"2";"3";"4"]
let s1 = RPN1 l1 stack0


// Finally

type Stack = StackContents of float list

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

// ==============================================
// Operator core
// ==============================================

// pop the top two elements
// do a binary operation on them
// push the result
let binary mathFn stack = 
    let y,stack' = pop stack    
    let x,stack'' = pop stack'  
    let z = mathFn x y
    push z stack''  

// Constants
// -------------------------------
let EMPTY = StackContents []
let START  = EMPTY

let op str =
    match str with
   | "+" -> binary (+)
   | "-" -> binary (-)
   | "*" -> binary (*)
   | "/" -> binary (/)

let rec RPN stringl stack =
    match stringl with
    | [] -> stack
    | (noOp & head) :: tail when not (isOperator noOp) -> RPN tail (push (float head) stack)
    | head :: tail -> RPN tail (op head stack)

// Test
let reqstring = "4 3 + 2 *"
let stack = EMPTY
let reqlist = words reqstring
let result = RPN reqlist stack
let x,_ = pop result
printfn "The answer is %f" x

let reqstring = "4 3 + 2 * 3 /"
let stack = EMPTY
let reqlist = words reqstring
let result = RPN reqlist stack
let x,_ = pop result
printfn "The answer to %s is %f" reqstring x