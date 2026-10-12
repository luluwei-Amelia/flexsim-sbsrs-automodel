/**Custom Code*/

treenode libraryCombiner = library().find("?Combiner");
Object firstCombiner = createinstance(libraryCombiner, model());//创建Combiner
firstCombiner.name="Combiner";
firstCombiner.setSize(3,3,1);
firstCombiner.location.x = xloc(Model.find("maincoveyor1"));
firstCombiner.location.y = yloc(Model.find("maincoveyor1"))-3;

contextdragconnection(Model.find("Combiner"),Model.find("maincoveyor1"),  "A");

setrot(Combiner,0,0,90);
