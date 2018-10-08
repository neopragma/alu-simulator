namespace AluSimulator.Tests

module Tests = 

    open Xunit
    open AluSimulator

    [<Theory>]
    [<InlineData(false, false, true)>]
    [<InlineData(false, true, true)>]
    [<InlineData(true, false, true)>]
    [<InlineData(true, true, false)>]
    let ``nandGate implements NAND logic`` a b q =
        Assert.Equal(q, ALU.nandGate a b)
       
    [<Theory>]
    [<InlineData(true, false)>]
    [<InlineData(false, true)>]
    let ``notGate implements NOT logic`` a q =
        Assert.Equal(q, ALU.notGate a)
        
    [<Theory>]
    [<InlineData(false, false, false)>]
    [<InlineData(true, false, true)>]
    [<InlineData(false, true, true)>]
    [<InlineData(true, true, true)>]
    let ``orGate implements OR logic`` a b q =
        Assert.Equal(q, ALU.orGate a b)
        
    [<Theory>]
    [<InlineData(true, true, true)>]
    [<InlineData(true, false, false)>]
    [<InlineData(false, true, false)>]
    [<InlineData(false, false, false)>]
    let ``andGate implements AND logic`` a b q =
        Assert.Equal(q, ALU.andGate a b)

    [<Theory>]
    [<InlineData(false, false, false, false)>]
    [<InlineData(false, true, true, false)>]
    [<InlineData(true, false, true, false)>]
    [<InlineData(true, true, false, true)>]
    let ``halfAdder adds two bits to produce a sum and carry bit`` a b (sum, carry) =
        let result = ALU.halfAdder a b 
        Assert.Equal(sum, fst result)
        Assert.Equal(carry, snd result)

    [<Theory>]
    [<InlineData(false, false, false, false, false)>]
    [<InlineData(false, false, true, true, false)>]
    [<InlineData(false, true, false, true, false)>]
    [<InlineData(false, true, true, false, true)>]
    [<InlineData(true, false, false, true, false)>]
    [<InlineData(true, false, true, false, true)>]
    [<InlineData(true, true, false, false, true)>]
    [<InlineData(true, true, true, true, true)>]
    let ``fullAdder adds two bits and considers the previous carry bit`` a b c (sum, carry) =
        let result = ALU.fullAdder a b c
        Assert.Equal(sum, fst result)
        Assert.Equal(carry, snd result)
