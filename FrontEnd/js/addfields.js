function addIngredientField() {
    let el = document.createElement("div")
    el.setAttribute("class", "ingredientset")

    // let recipeId = document.createElement("input")
    // recipeId.setAttribute("type", "text")
    // recipeId.setAttribute("class", "recipeId")

    // let ingredientId = document.createElement("input")
    // ingredientId.setAttribute("type", "text")
    // ingredientId.setAttribute("class", "ingredientId")

    let ingredientName = document.createElement("input")
    ingredientName.setAttribute("type", "text")
    ingredientName.setAttribute("class", "ingredientName")

    let quantity = document.createElement("input")
    quantity.setAttribute("type", "text")
    quantity.setAttribute("class", "quantity")

    let unit = document.createElement("input")
    unit.setAttribute("type", "text")
    unit.setAttribute("class", "unit")

    // el.appendChild(recipeId)
    // el.appendChild(ingredientId)
    el.appendChild(ingredientName)
    el.appendChild(quantity)
    el.appendChild(unit)

    return el
}

function addInstructionField(){
    let el = document.createElement("div")
    el.setAttribute("class", "instructionset")

    // let recipeId = document.createElement("input")
    // recipeId.setAttribute("type", "text")
    // recipeId.setAttribute("class", "recipeId")

    let instruction = document.createElement("input")
    instruction.setAttribute("type", "text")
    instruction.setAttribute("class", "instruction")

    // el.appendChild(recipeId)
    el.appendChild(instruction)
    return el
}