/*
 * Vue document.get10
 */

 Design Document Name: document
 View Name: document.get10

function (doc, meta) {
  if(doc.type === "Document"){
    emit(doc.dateDePublication,{
      id : doc.id,
      titre : doc.titre,
      domaine : doc.domaine,
      discipline : doc.discipline, 
      niveau: doc.niveau,
      dateDePublication : doc.dateDePublication});
     }  
}