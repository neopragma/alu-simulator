namespace AluSimulator

module ALU =

    let nandGate a b = not (a && b)

    let notGate a = nandGate a a

    let orGate a b = nandGate (nandGate a a) (nandGate b b)

    let andGate a b = nandGate (nandGate a b) (nandGate a b)

    let halfAdder a b = 
        let u1 = nandGate a b
        let u3 = nandGate a u1
        let u4 = nandGate b u1
        let sum = nandGate u3 u4
        let carry = nandGate u1 u1
        sum, carry

    let fullAdder a b c = 
        let result1 = halfAdder a b
        let sum1 = fst result1
        let carry1 = snd result1
        let result2 = halfAdder sum1 c
        let carry2 = snd result2 
        let carry = orGate carry1 carry2
        let sum = fst result2 
        sum, carry

    let fullAdderx a b c = 
        let u1 = nandGate a b
        let u3 = nandGate a u1
        let u4 = nandGate b u1
        let sum1 = nandGate u3 u4
        let u5 = nandGate sum1 c
        let u6 = nandGate sum1 u5
        let u7 = nandGate u5 c 
        let sum = nandGate u6 u7
        let carry = nandGate u1 u5 
        sum, carry 

