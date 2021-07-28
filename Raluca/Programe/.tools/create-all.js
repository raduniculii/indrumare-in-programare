const fs = require("fs");
const path = require("path");

console.log("Incepem generarea...");

const dateString = (function(now){
    return [
        now.getFullYear()
        , ('0' + (now.getMonth() + 1)).substr(-2, 2)
        , ('0' + now.getDate()).substr(-2, 2)
    ].join('-');
})(new Date());

const MAX_FOLDERS_PER_DAY = 999;
let ix = 0;
let dirToCreate = null;

while(ix <= MAX_FOLDERS_PER_DAY){
    ix++;
    dirToCreate = path.join(process.cwd(), `${dateString}-${('00' + ix).substr(-3, 3)}`);
    if(fs.existsSync(dirToCreate)) continue;

    fs.mkdirSync(dirToCreate);
    break;
}
if(ix > MAX_FOLDERS_PER_DAY) {
    console.error("Prea multe foldere facut-ai azi. Mai sterge cateva si mai incearca.");
    return;
}

console.log(`Directorul ${dirToCreate} a fost creat...`);
let csPath = path.join(dirToCreate, "cs");
let jsPath = path.join(dirToCreate, "js");
let pyPath = path.join(dirToCreate, "python");

fs.mkdirSync(csPath);
fs.mkdirSync(jsPath);
fs.mkdirSync(pyPath);

console.log(`... la fel si subdirectoarele cs, js si python...`);
console.log(`Se initializeaza proiectul de C#, va dura putin...`);
const child_process = require("child_process");
child_process.execSync("dotnet new console -n \"test\" -o .", { cwd: path.join(dirToCreate, "/cs"), stdio: "inherit" });

fs.writeFileSync(path.join(csPath, "Program.cs")
    , fs.readFileSync(path.join(csPath, "Program.cs"), { encoding: "utf-8" }).replace(/Console\.WriteLine\(\"[^"]*\"\)/, "Console.WriteLine(\"C# merge!\")")
    , { encoding: "utf-8" }
);
console.log(`Proiectul de C# e initializat...`);

fs.writeFileSync(path.join(jsPath, "test.js"), `const readLine = require("./readLine");

console.log("JS merge!");`, { encoding: "utf-8" });
fs.writeFileSync(
    path.join(jsPath, "readLine.js")
    , fs.readFileSync(path.join(process.cwd(), "/.tools/", "readLine.js"), { encoding: "utf-8" })
    , { encoding: "utf-8" }
);

fs.writeFileSync(path.join(pyPath, "test.py"), "print(\"Python merge!\")", { encoding: "utf-8" });
console.log(`Fisierele pentru js si python sunt si ele la locurile lor...`);

//Create .vscode dir and contents
let vsCodeDir = path.join(dirToCreate, ".vscode");
fs.mkdirSync(vsCodeDir);
fs.writeFileSync(
    path.join(vsCodeDir, "launch.json")
    , fs.readFileSync(path.join(process.cwd(), "/.tools/", "launch.json"), { encoding: "utf-8" })
    , { encoding: "utf-8" }
);
fs.writeFileSync(
    path.join(vsCodeDir, "tasks.json")
    , fs.readFileSync(path.join(process.cwd(), "/.tools/", "tasks.json"), { encoding: "utf-8" })
    , { encoding: "utf-8" }
);
//Done creating .vscode dir and contents

writeRunBat("cs", "C#", "cs", "dotnet run");
writeRunBat("js", "JavaScript (nu confunda cu Java)", "js", "node test.js");
writeRunBat("py", "Python", "python", "py test.py");



console.log(`Totul este gata, poti deschide ${dirToCreate} cu VS Code si sa lucrezi direct in fisierele cs, js, sau py.`);

console.log("Poti apasa orice tasta pentru a iesi...");
process.stdin.setRawMode(true);
process.stdin.resume();
process.stdin.on("data", process.exit.bind(process, 0));

function writeRunBat(langBatId, langBigName, folder, command){
    fs.writeFileSync(path.join(dirToCreate, `run-${langBatId}.bat`), `@echo __________________________________________ Se porneste programul din ${langBigName}
@echo:
@echo:
@cd ${folder}
@${command}
@cd ..
@echo:
@echo:
@echo __________________________________________ Programul din ${langBigName} s-a incheiat
`
    , { encoding: "utf-8" });
}
