#YACLP
##Yet Another Command-Line Parser

YACLP is yet another command-line parser. It's designed to be quick to include and invoke, and require very little work. The key feature of YACLP is its intelligent generation of usage messages when command-line input does not comply with parsing rules.

##Example Usage
    
    var options = DefaultParser.ParseOrExitWithUsageMessage<MyCommandLineParameters>(args);
