﻿module Fantomas.Core.Tests.Stroustrup.FunctionApplicationSingleListTests

open NUnit.Framework
open FsUnit
open Fantomas.Core.Tests.TestHelper
open Fantomas.Core.FormatConfig

let config =
    { config with
        MultilineBracketStyle = ExperimentalStroustrup }

[<Test>]
let ``short function application`` () =
    formatSourceString
        false
        """
fn [   b1;   b1 ]
"""
        config
    |> prepend newline
    |> should
        equal
        """
fn [ b1; b1 ]
"""

[<Test>]
let ``short function application with additional parameters`` () =
    formatSourceString
        false
        """
fn a b [   b1;   b1 ]
"""
        config
    |> prepend newline
    |> should
        equal
        """
fn a b [ b1; b1 ]
"""

[<Test>]
let ``function application where the list is multiline`` () =
    formatSourceString
        false
        """
fn [   b1; // some comment
       b2]
"""
        config
    |> prepend newline
    |> should
        equal
        """
fn [
    b1 // some comment
    b2
]
"""

[<Test>]
let ``short function application where the list is multiline and additional parameters`` () =
    formatSourceString
        false
        """
fn a b [   b1; // comment
           b2 ]
"""
        config
    |> prepend newline
    |> should
        equal
        """
fn a b [
    b1 // comment
    b2
]
"""

[<Test>]
let ``short function application with additional multiline parameters`` () =
    formatSourceString
        false
        """
fn a b (try somethingDangerous with ex -> printfn "meh" ) c [   b1; // comment
           b2 ]
"""
        config
    |> prepend newline
    |> should
        equal
        """
fn
    a
    b
    (try
        somethingDangerous
     with ex ->
         printfn "meh")
    c
    [
        b1 // comment
        b2
    ]
"""
