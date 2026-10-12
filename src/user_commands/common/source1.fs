/**Custom Code*/

treenode librarySource = maintree().find("project/userlibrary/UserLibrary 1/source1");

//treenode librarySource = library().find("?Source");
Object firstSource = createinstance(librarySource, model());//创建Soure

//setvarnum(firstSource, "itemclass", 7);

firstSource.name="source1";
firstSource.setSize(1,1,0.5);
firstSource.location.x = xloc(Model.find("Combiner"))-3;
firstSource.location.y = yloc(Model.find("Combiner"))+1;

contextdragconnection(Model.find("source1"),Model.find("Combiner"),  "A");
