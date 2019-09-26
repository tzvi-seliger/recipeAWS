function addIngredientField(index) {
  let el = document.createElement("div");
  el.setAttribute("class", "ingredientset");

  ////////////////////////IngredientName//////////////////////////////
  let ingredientNameLabel = document.createElement("label");
  ingredientNameLabel.setAttribute("for", "ingredientName" + index);
  ingredientNameLabel.innerHTML = "Ingredient Name";

  let ingredientName = document.createElement("input");
  ingredientName.setAttribute("type", "text");
  ingredientName.setAttribute("class", "ingredientName");
  ingredientName.setAttribute("id", "ingredientName" + index);
  ////////////////////////EndIngredientName//////////////////////////////

  ///////////////////////Quantity///////////////////////////////////////
  let quantityLabel = document.createElement("label");
  quantityLabel.setAttribute("for", "quantity" + index);
  quantityLabel.innerHTML = "quantity";

  let quantity = document.createElement("input");
  quantity.setAttribute("type", "text");
  quantity.setAttribute("class", "quantity");
  quantity.setAttribute("id", "quantity" + index);
  //////////////////////ENDQuantity/////////////////////////////////////

   //////////////////////Unit/////////////////////////////////////
  let unitLabel = document.createElement("label");
  unitLabel.setAttribute("for", "unit" + index);
  unitLabel.innerHTML = "Unit";
  
  let unit = document.createElement("input");
  unit.setAttribute("type", "text");
  unit.setAttribute("class", "unit");
  unit.setAttribute("id", "unit" + index);
  //////////////////////ENDUnit/////////////////////////////////////

  
  el.appendChild(ingredientNameLabel);
  el.appendChild(ingredientName);

  el.appendChild(quantityLabel);
  el.appendChild(quantity);

  el.appendChild(unitLabel);
  el.appendChild(unit);

  return el;
}

function addInstructionField() {
  let el = document.createElement("div");
  el.setAttribute("class", "instructionset");

  // let recipeId = document.createElement("input")
  // recipeId.setAttribute("type", "text")
  // recipeId.setAttribute("class", "recipeId")

  let instruction = document.createElement("input");
  instruction.setAttribute("type", "text");
  instruction.setAttribute("class", "instruction");

  // el.appendChild(recipeId)
  el.appendChild(instruction);
  return el;
}
