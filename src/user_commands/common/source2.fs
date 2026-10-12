/**Custom Code*/


treenode librarySource = maintree().find("project/userlibrary/UserLibrary 1/source2");
Object firstSource = createinstance(librarySource, model());//创建Soure

//setvarnum(firstSource, "itemclass", 1);

firstSource.name="source2";
firstSource.setSize(1,1,0.5);
firstSource.location.x = xloc(Model.find("Combiner"))-3;
firstSource.location.y = yloc(Model.find("Combiner"))-2;

contextdragconnection(Model.find("source2"),Model.find("Combiner"),  "A");
