[![License: AGPL v3](https://img.shields.io/badge/License-AGPL_v3-blue.svg)](https://www.gnu.org/licenses/agpl-3.0)
![version](https://img.shields.io/badge/version-1.0-green)

# MergePDF

## Introduction

MergePDF is a simple lightweight windows forms application for merging PDFs, 
written in C\#, and published using .NET Core. 

The final self-contained build is located in ___.

## Dependencies

### iTextSharp <!-- <img align="left" width="80" height="80" src="" alt="iTextSharp icon">  :todo: -->
```
PM> NuGet\Install-Package iTextSharp -Version 5.5.13.3
```

#### Microsoft.Web.WebView2
```
PM> NuGet\Install-Package Microsoft.Web.WebView2 -Version 1.0.1988-prerelease
```

## Application Features

This application allows you to select multiple pdf files, to merge into a 
single pdf file. 

<!-- mainForm img -->

It has advanced merge options allowing for page selection and reordering from
selected pdf files.

<!-- mergeForm img -->

For example the above image shows a selection of page 1 of the first 
pdf, page 2 from the second pdf, page 3 from the first pdf, etc...

## License

This project is licensed under the [GNU Affero General Public License v3.0](https://www.gnu.org/licenses/agpl-3.0.en.html "GNU Affero General Public License v3.0").