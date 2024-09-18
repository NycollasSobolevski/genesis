const vscode = require('vscode');

function activate(context) {
const provider0 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('nat', vscode.CompletionItemKind.Keyword);
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider0);
	const provider1 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('real', vscode.CompletionItemKind.Keyword);
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider1);
	const provider2 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('int', vscode.CompletionItemKind.Keyword);
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider2);
	const provider3 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('rat', vscode.CompletionItemKind.Keyword);
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider3);
	const provider4 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('subset', vscode.CompletionItemKind.Keyword);
			comp.insertText = new vscode.SnippetString('subset of ${1|subset,nat,real,int,rat|}');
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider4);
	const provider5 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('given', vscode.CompletionItemKind.Keyword);
			comp.insertText = new vscode.SnippetString('given ${1:id} in ${2|subset,nat,real,int,rat|}');
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider5);
	const provider6 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('define', vscode.CompletionItemKind.Keyword);
			comp.insertText = new vscode.SnippetString('define ${1:id} as ${2|subset,nat,real,int,rat|}');
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider6);
	const provider7 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('check', vscode.CompletionItemKind.Keyword);
			comp.insertText = new vscode.SnippetString('check if ${1:inclusion}');
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider7);
	const provider8 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('not', vscode.CompletionItemKind.Keyword);
			comp.insertText = new vscode.SnippetString('not ${1:boolean}');
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider8);
	const provider9 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('if', vscode.CompletionItemKind.Keyword);
			comp.insertText = new vscode.SnippetString('if ${1:cond} then ${2:inclusion}');
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider9);
	const provider10 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('for', vscode.CompletionItemKind.Keyword);
			comp.insertText = new vscode.SnippetString('for ${1|some,all|} ${2:id} in ${3|subset,nat,real,int,rat|}');
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider10);
	const provider11 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('considering', vscode.CompletionItemKind.Keyword);
			comp.insertText = new vscode.SnippetString('considering ${1:id}');
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider11);
	const provider12 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('some', vscode.CompletionItemKind.Keyword);
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider12);
	const provider13 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('all', vscode.CompletionItemKind.Keyword);
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider13);
	const provider14 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('of', vscode.CompletionItemKind.Keyword);
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider14);const provider15 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('is', vscode.CompletionItemKind.Keyword);
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider15);const provider16 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('and', vscode.CompletionItemKind.Keyword);
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider16);const provider17 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('or', vscode.CompletionItemKind.Keyword);
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider17);const provider18 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('as', vscode.CompletionItemKind.Keyword);
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider18);const provider19 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('contains', vscode.CompletionItemKind.Keyword);
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider19);const provider20 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('then', vscode.CompletionItemKind.Keyword);
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider20);const provider21 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	        const comp = new vscode.CompletionItem('in', vscode.CompletionItemKind.Keyword);
			comp.commitCharacters = [' '];
			return [ comp ];
	
	    }
	});
	context.subscriptions.push(provider21);const provider23 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	            const linePrefix = document.lineAt(position).text.slice(0, position.character);
			    if (!linePrefix.endsWith('subset ')) {
			        return undefined;
			    }
			
			    const comp = new vscode.CompletionItem('of');
			    comp.insertText = new vscode.SnippetString('of');
			    return [ comp ];
	
	    }
	}, ' ');
	context.subscriptions.push(provider23);
	const provider24 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	            const linePrefix = document.lineAt(position).text.slice(0, position.character);
			    if (!linePrefix.endsWith('of ')) {
			        return undefined;
			    }
			
			    const comp = new vscode.CompletionItem('set');
			    comp.insertText = new vscode.SnippetString('${1|subset,nat,real,int,rat|}');
			    return [ comp ];
	
	    }
	}, ' ');
	context.subscriptions.push(provider24);
	const provider25 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	            const linePrefix = document.lineAt(position).text.slice(0, position.character);
			    if (!linePrefix.endsWith('is ')) {
			        return undefined;
			    }
			
			    const comp = new vscode.CompletionItem('value');
			    comp.insertText = new vscode.SnippetString('${1:value}');
			    return [ comp ];
	
	    }
	}, ' ');
	context.subscriptions.push(provider25);
	const provider26 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	            const linePrefix = document.lineAt(position).text.slice(0, position.character);
			    if (!linePrefix.endsWith('and ')) {
			        return undefined;
			    }
			
			    const comp = new vscode.CompletionItem('cond');
			    comp.insertText = new vscode.SnippetString('${1:cond}');
			    return [ comp ];
	
	    }
	}, ' ');
	context.subscriptions.push(provider26);
	const provider27 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	            const linePrefix = document.lineAt(position).text.slice(0, position.character);
			    if (!linePrefix.endsWith('or ')) {
			        return undefined;
			    }
			
			    const comp = new vscode.CompletionItem('cond');
			    comp.insertText = new vscode.SnippetString('${1:cond}');
			    return [ comp ];
	
	    }
	}, ' ');
	context.subscriptions.push(provider27);
	const provider28 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	            const linePrefix = document.lineAt(position).text.slice(0, position.character);
			    if (!linePrefix.endsWith('not ')) {
			        return undefined;
			    }
			
			    const comp = new vscode.CompletionItem('boolean');
			    comp.insertText = new vscode.SnippetString('${1:boolean}');
			    return [ comp ];
	
	    }
	}, ' ');
	context.subscriptions.push(provider28);
	const provider29 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	            const linePrefix = document.lineAt(position).text.slice(0, position.character);
			    if (!linePrefix.endsWith('define ')) {
			        return undefined;
			    }
			
			    const comp = new vscode.CompletionItem('id');
			    comp.insertText = new vscode.SnippetString('${1:id}');
			    return [ comp ];
	
	    }
	}, ' ');
	context.subscriptions.push(provider29);
	const provider30 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	            const linePrefix = document.lineAt(position).text.slice(0, position.character);
			    if (!linePrefix.endsWith('as ')) {
			        return undefined;
			    }
			
			    const comp = new vscode.CompletionItem('set');
			    comp.insertText = new vscode.SnippetString('${1|subset,nat,real,int,rat|}');
			    return [ comp ];
	
	    }
	}, ' ');
	context.subscriptions.push(provider30);
	const provider31 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	            const linePrefix = document.lineAt(position).text.slice(0, position.character);
			    if (!linePrefix.endsWith('contains ')) {
			        return undefined;
			    }
			
			    const comp = new vscode.CompletionItem('value');
			    comp.insertText = new vscode.SnippetString('$1');
			    return [ comp ];
	
	    }
	}, ' ');
	context.subscriptions.push(provider31);
	const provider32 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	            const linePrefix = document.lineAt(position).text.slice(0, position.character);
			    if (!linePrefix.endsWith('if ')) {
			        return undefined;
			    }
			
			    const comp = new vscode.CompletionItem('inclusion');
			    comp.insertText = new vscode.SnippetString('${1|for,not|}');
			    return [ comp ];
	
	    }
	}, ' ');
	context.subscriptions.push(provider32);
	const provider33 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	            const linePrefix = document.lineAt(position).text.slice(0, position.character);
			    if (!linePrefix.endsWith('then ')) {
			        return undefined;
			    }
			
			    const comp = new vscode.CompletionItem('inclusion');
			    comp.insertText = new vscode.SnippetString('${1:inclusion}');
			    return [ comp ];
	
	    }
	}, ' ');
	context.subscriptions.push(provider33);
	const provider34 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	            const linePrefix = document.lineAt(position).text.slice(0, position.character);
			    if (!linePrefix.endsWith('for ')) {
			        return undefined;
			    }
			
			    const comp = new vscode.CompletionItem('fortype');
			    comp.insertText = new vscode.SnippetString('${1|some,all|}');
			    return [ comp ];
	
	    }
	}, ' ');
	context.subscriptions.push(provider34);
	const provider35 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	            const linePrefix = document.lineAt(position).text.slice(0, position.character);
			    if (!linePrefix.endsWith('in ')) {
			        return undefined;
			    }
			
			    const comp = new vscode.CompletionItem('set');
			    comp.insertText = new vscode.SnippetString('${1|subset,nat,real,int,rat|}');
			    return [ comp ];
	
	    }
	}, ' ');
	context.subscriptions.push(provider35);
	const provider36 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	            const linePrefix = document.lineAt(position).text.slice(0, position.character);
			    if (!linePrefix.endsWith('check ')) {
			        return undefined;
			    }
			
			    const comp = new vscode.CompletionItem('if');
			    comp.insertText = new vscode.SnippetString('if');
			    return [ comp ];
	
	    }
	}, ' ');
	context.subscriptions.push(provider36);
	const provider37 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	            const linePrefix = document.lineAt(position).text.slice(0, position.character);
			    if (!linePrefix.endsWith('considering ')) {
			        return undefined;
			    }
			
			    const comp = new vscode.CompletionItem('id');
			    comp.insertText = new vscode.SnippetString('${1:id}');
			    return [ comp ];
	
	    }
	}, ' ');
	context.subscriptions.push(provider37);
	const provider38 = vscode.languages.registerCompletionItemProvider('bruteforce', {
	
	    provideCompletionItems(document, position) {
	    
	            const linePrefix = document.lineAt(position).text.slice(0, position.character);
			    if (!linePrefix.endsWith('given ')) {
			        return undefined;
			    }
			
			    const comp = new vscode.CompletionItem('id');
			    comp.insertText = new vscode.SnippetString('${1:id}');
			    return [ comp ];
	
	    }
	}, ' ');
	context.subscriptions.push(provider38);
	

}

function deactivate() {}

module.exports = {
    activate,
    deactivate
}