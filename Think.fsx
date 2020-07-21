// an example using List.map
let add1 = (+) 1
let add1ToEach = List.map add1   // fix the "add1" function

// test
add1ToEach [1;2;3;4]

// an example using List.filter
let filterEvens = 
   List.filter (fun i -> i%2 = 0) // fix the filter function

// test
filterEvens [1;2;3;4]

// create an adder that supports a pluggable logging function
let adderWithPluggableLogger logger x y = 
    logger "x" x
    logger "y" y
    let result = x + y
    logger "x+y"  result 
    result 

// create a logging function that writes to the console
let consoleLogger argName argValue = 
    printfn "%s=%A" argName argValue 

//create an adder with the console logger partially applied
let addWithConsoleLogger = adderWithPluggableLogger consoleLogger 
addWithConsoleLogger  1 2 
addWithConsoleLogger  42 99


// piping using list functions
let result = 
   [1..10]
   |> List.map (fun i -> i+1)
   |> List.filter (fun i -> i>5)




