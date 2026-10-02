window.emailEditor = {

    savedRange: null,

    saveSelection: function (editor) {

        if (!editor)
            return;

        const selection = window.getSelection();

        if (!selection ||
            selection.rangeCount === 0)
            return;

        const range = selection.getRangeAt(0);

        if (editor.contains(range.commonAncestorContainer)) {

            this.savedRange = range.cloneRange();

        }
    },


    restoreSelection: function (editor) {

        if (!editor ||
            !this.savedRange)
            return;

        const selection = window.getSelection();

        selection.removeAllRanges();

        selection.addRange(
            this.savedRange
        );
    },


    command: function (
        editor,
        command,
        value) {

        if (!editor)
            return;

        editor.focus();

        this.restoreSelection(editor);

        document.execCommand(
            command,
            false,
            value || null
        );

        this.saveSelection(editor);

        editor.focus();
    },

    backspace: function (editor) {

        if (!editor)
            return;

        editor.focus();

        this.restoreSelection(editor);

        document.execCommand(
            "delete",
            false,
            null
        );

        this.saveSelection(editor);

        editor.focus();
    },



    insertHtml: function (
        editor,
        html) {

        if (!editor)
            return;

        editor.focus();

        this.restoreSelection(editor);

        document.execCommand(
            "insertText",
            false,
            html
        );

        this.saveSelection(editor);

        editor.focus();
    },


    createLink: function (
        editor,
        url) {

        if (!editor)
            return;

        editor.focus();

        this.restoreSelection(editor);

        document.execCommand(
            "createLink",
            false,
            url
        );

        this.saveSelection(editor);

        editor.focus();
    },


    getHtml: function (editor) {

        if (!editor)
            return "";

        return editor.innerHTML;
    }
};