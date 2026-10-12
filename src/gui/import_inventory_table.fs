string directory = modeldir();
if (stringlen(directory) < 3) directory = documentsdir();
string path = filebrowse("*.xls*","Excel Workbooks",directory);
if (stringlen(path) > 4) {
	if (stringlen(modeldir()) > 3) {
		path = stringreplace(path, modeldir(), "");
	}
	sets(node(">temp",c), path);
	setviewtext(node("../editWorkbook",c), path);
	set(itemcurrent(node("../editWorkbook",c)),0);
}
