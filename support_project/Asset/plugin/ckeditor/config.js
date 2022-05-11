/**
 * @license Copyright (c) 2003-2022, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	
    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowseUrl = '/Asset/plugin/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Asset/plugin/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/Asset/plugin/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/Asset/plugin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Asset/Image';
    config.filebrowserFlashUploadUrl = '/Asset/plugin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    CKFinder.setupCKEditor(null, '/Asset/plugin/ckfinder/');

};
