namespace Namespace1

open System
open System.Runtime.InteropServices

/// Documentation for Module1.
module Module1 =

    type MyAbrev1 = int * float

    type MyAbrev2 = string

    type MyAbrev3 = int -> float

    /// Description for MyRec1
    type MyRec1 = {
        /// Description for field1
        field1: string
        /// Description for field2
        field2: int}

    type MyUnion1 =
        | UnionCase1
        | UnionCase2 of MyRec1

    /// Constant 1
    let const1 = 2.0

    let funcRec1 (t: MyRec1) =
        t

    let funcUnion1 (t: MyUnion1) =
        t

    /// Documentation for func0.
    let func0 (strArg1, intArg2) =
        printfn "Hello %s %d" strArg1 intArg2

    /// <summary>Documentation for func1.</summary>
    /// <param name="strArg1">Documentation for strArg1</param>
    /// <param name="intArg2">Documentation for intArg2.</param>
    let func1 strArg1 intArg2 =
        printfn "Hello %s %d" strArg1 intArg2

    let func1Ary (arrayArg1: int[]) =
        ()

    let funcAbrev123 (abrevArg1: MyAbrev1, abrevArg2: MyAbrev2, abrevArg3: MyAbrev3) =
        "bla"

    let funcAbrev1 (abrevArg1: MyAbrev1) =
        "bla"        

    let funcAbrev2 (abrevArg2: MyAbrev2) =
        "bla"        

    let funcAbrev3 (abrevArg3: MyAbrev3) =
        "bla"        

    let funcAbrevRet () : MyAbrev3  =
        (fun x -> 12.2)

    /// Documentation for inlineFunc2.
    let inline inlineFunc2 genArg1 intArg2 genArg3 =
        if intArg2 > 1 then
            genArg1 + genArg1, genArg3 - genArg3
        else
            genArg1, genArg3

    /// <summary>Documentation for func3.</summary>
    /// <param name="optArg1">optional arugment 1</param>
    /// <returns>Something valuable</returns>
    let func3 optArg1 =
        match optArg1 with
        | Some number -> number
        | None -> 0

    /// Documentation for func4.
    let func4 (arg1: Map<string, int>) =
        10.2

    /// MyException docs
    exception MyException

    exception BException of string

    /// MyOtherException documentation
    exception MyOtherException of name:string * size:int with member __.Hallo() = 123

    /// <summary>Delegate documentation</summary>
    /// <param name="arg2">Docu for arg2</param>
    /// <returns>Something</returns>
    type MyDelegate = delegate of arg1:int * arg2:MyRec1 -> (string -> int)

    type MyDelegate2 = delegate of unit -> string 

    type MyDelegate3 = delegate of unit -> unit

    let myFuncRetDel (a: MyDelegate2) : MyDelegate =
        null
    
/// Documentation for Module2.
module Module2 =

    /// Documentation for cm.
    [<Measure>]
    type cm

    /// Documentation for squareArea.
    let squareArea (length: float<cm>) =
        length * length


/// Documentation for Module3.
module Module3 =

    /// Documentation for UnionType.
    type UnionType =
        /// Documentation for UnionChoice1.
        | UnionChoice1
        /// Documentation for UnionChoice2.
        | UnionChoice2 of int
        /// Documentation for UnionChoice3.
        | UnionChoice3 of name:string * size:int    
           
    /// Documentation for RecordType.
    [<Obsolete("Obsolete notice", error=false); Struct>]
    type RecordType = {
        /// Documentation for Field1.
        Field1: string
        /// Documentation for Field2.
        Field2: double
    }

    /// Documentation for GenericRecordType<'T>.
    type GenericRecordType<'T> = {
        /// Documentation for Field1.
        Field1: string
        /// Documentation for Field2.
        Field2: 'T option
    }

    /// Makes int instance.
    let makeIntInst() =
        {Field1="bla"; Field2=Some 123}

    /// Makes int instance.
    let optionalReturn() =
        Some {RecordType.Field1="bla"; Field2=234.1}        


/// Documentation for Module4.
module Module4 =

    /// Documentation for active recognizier Even/Odd.
    let (|Even|Odd|) number =
        if number % 2 = 0 then Even
        else Odd

    /// Documentation for partial active recognizier Prime.
    let (|Prime|_|) number =
        if number = 0 then Some Prime
        else None

    /// Documentation for active recognizer with output.
    let (|Tenths|) number =
        (number / 10, number % 10)


/// Documentation for Module5.
module Module5 =

    /// IMyInterface docs
    type IMyInterface =
        /// Doc for InterfaceMethod
        abstract InterfaceMethod: string -> int

    /// <summary>Documentation for Type1.</summary>
    /// <param name="argument1">Argument1 constructor arg</param>
    /// <param name="argument2">Argument2 constructor arg</param>
    type Type1(argument1: int,
               argument2: string) =

        let internalVar = argument1

        /// Altetnative constructor docs
        new (altArg1: float) = Type1(1, "hallo")

        /// Arg1 docs
        member __.Arg1 = argument1

        /// Arg2 docs
        member __.Arg2 = argument2

        /// ValProperty1 docs.
        member val ValProperty1 = 123 with get, set

        /// TupleMethod docs for override 1.
        member __.TupledMethod(arg1: string, arg2) =
            sprintf "%s%d" arg1 arg2

        /// TupleMethod docs for override 2.
        member __.TupledMethod(arg1: string, arg2) =
            sprintf "%s%f" arg1 arg2

        /// CurriedMethod docs.
        member __.CurriedMethod arg1 arg2 =
            sprintf "%f%s" arg1 arg2

        /// StaticMethod docs.
        static member StaticMethod(arg1: int, arg2: byte) =
            arg1 + int arg2

        /// GenericMethod docs.
        member __.GenericMethod (arg1, arg2) =
            match arg1 with 
            | Some _ -> arg2
            | _ -> arg2 + arg2

        interface ICloneable with
            member __.Clone() = null

        /// Virtual method docs
        abstract member VirtualMethod: int -> int

        /// Default impl docs
        default __.VirtualMethod arg1 = arg1 + 2

    /// Type2 derived from Type1
    type Type2() =
        inherit Type1(123, "bla")

        member __.NewMethod() =
            "bla"

        override __.VirtualMethod bla = 
            bla + 10

        interface IMyInterface with
            /// Documentation for InterfaceMethod implementation
            member __.InterfaceMethod bla = 
                123

    let makeType1() =
        Type1(123, "bla")


    /// AbstractBaseType docs
    [<AbstractClass>]
    type AbstractBaseType() =
        /// AbstractProperty docs
        abstract member AbstractPropery: int with get, set

    /// ImplClass for AbstractBaseType
    type ImplClass() =
        inherit AbstractBaseType()

        let event1 = new Event<_>()

        [<CLIEvent>]
        member this.Event1 = event1.Publish

        member this.TestEvent(arg: int) =
            event1.Trigger(this, arg)

        /// Implementation docs for AbstractPropery
        override __.AbstractPropery 
            with get () = 123
            and set value = printfn "hi %d" value

    let myInst = ImplClass()
    do myInst.Event1.Add (fun bla -> printfn "%A" bla)

        