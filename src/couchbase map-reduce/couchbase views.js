/*
 * Vue document.get10
 */

 Design Document Name: dev_document
 View Name: document.get10

 function (doc, meta) {
  if(doc.type === "Document"){
     	emit(doc.dateDePublication, [doc.domaine, doc.discipline, doc.niveau]);
     }  
}