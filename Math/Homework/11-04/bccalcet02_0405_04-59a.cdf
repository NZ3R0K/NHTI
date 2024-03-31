(* Content-type: application/vnd.wolfram.cdf.text *)

(*** Wolfram CDF File ***)
(* http://www.wolfram.com/cdf *)

(* CreatedBy='Mathematica 8.0' *)

(*************************************************************************)
(*                                                                       *)
(*  The Mathematica License under which this file was created prohibits  *)
(*  restricting third parties in receipt of this file from republishing  *)
(*  or redistributing it by any means, including but not limited to      *)
(*  rights management or terms of use, without the express consent of    *)
(*  Wolfram Research, Inc.                                               *)
(*                                                                       *)
(*************************************************************************)

(*CacheID: 234*)
(* Internal cache information:
NotebookFileLineBreakTest
NotebookFileLineBreakTest
NotebookDataPosition[       835,         17]
NotebookDataLength[     82876,       1626]
NotebookOptionsPosition[     50205,        867]
NotebookOutlinePosition[     83652,       1638]
CellTagsIndexPosition[     83609,       1635]
WindowTitle->Section 4.5, Figure 4.59a
WindowFrame->Normal*)

(* Beginning of Notebook Content *)
Notebook[{
Cell[BoxData[
 FrameBox[
  TagBox[
   StyleBox[
    DynamicModuleBox[{$CellContext`xValue$$ = -0.1, $CellContext`zoomLevel$$ =
      0, Typeset`show$$ = True, Typeset`bookmarkList$$ = {}, 
     Typeset`bookmarkMode$$ = "Menu", Typeset`animator$$, Typeset`animvar$$ = 
     1, Typeset`name$$ = "\"untitled\"", Typeset`specs$$ = {{
       Hold[
       "Location of point \!\(\*\nStyleBox[\"P\",\nFontSlant->\"Italic\"]\)"],
        Manipulate`Dump`ThisIsNotAControl}, {{
        Hold[$CellContext`xValue$$], -0.1, ""}, {-0.1 -> 
        Pane["\!\(TraditionalForm\`x = a\)", {48, Automatic}, Alignment -> 
          Center], 0.6 -> 
        Pane["\!\(TraditionalForm\`x = b\)", {48, Automatic}, Alignment -> 
          Center], 1.6 -> 
        Pane["\!\(TraditionalForm\`x = c\)", {48, Automatic}, Alignment -> 
          Center]}}, {
       Hold["Zoom in to \!\(\*\nStyleBox[\"P\",\nFontSlant->\"Italic\"]\)"], 
       Manipulate`Dump`ThisIsNotAControl}, {{
        Hold[$CellContext`zoomLevel$$], 0, ""}, 0, 5}}, Typeset`size$$ = {
     288., {137., 142.}}, Typeset`update$$ = 0, Typeset`initDone$$, 
     Typeset`skipInitDone$$ = False, $CellContext`xValue$8436$$ = 
     False, $CellContext`zoomLevel$8437$$ = 0}, 
     DynamicBox[Manipulate`ManipulateBoxes[
      1, StandardForm, 
       "Variables" :> {$CellContext`xValue$$ = -0.1, $CellContext`zoomLevel$$ = 
         0}, "ControllerVariables" :> {
         Hold[$CellContext`xValue$$, $CellContext`xValue$8436$$, False], 
         Hold[$CellContext`zoomLevel$$, $CellContext`zoomLevel$8437$$, 0]}, 
       "OtherVariables" :> {
        Typeset`show$$, Typeset`bookmarkList$$, Typeset`bookmarkMode$$, 
         Typeset`animator$$, Typeset`animvar$$, Typeset`name$$, 
         Typeset`specs$$, Typeset`size$$, Typeset`update$$, 
         Typeset`initDone$$, Typeset`skipInitDone$$}, "Body" :> 
       Show[{$CellContext`staticPlotC4F59a, 
          Plot[
          Derivative[
             1][$CellContext`funcC4F59a][$CellContext`xValue$$] \
($CellContext`x - $CellContext`xValue$$) + \
$CellContext`funcC4F59a[$CellContext`xValue$$], {$CellContext`x, -2, 3}, 
           AxesOrigin -> {0, 0}, PlotStyle -> {{Thick, $CellContext`bcR}}, 
           MaxRecursion -> 2], 
          Graphics[{Black, 
            AbsolutePointSize[6], 
            Point[{$CellContext`xValue$$, 
              $CellContext`funcC4F59a[$CellContext`xValue$$]}], 
            Text["\!\(TraditionalForm\`P\)", {$CellContext`xValue$$, 
              $CellContext`funcC4F59a[$CellContext`xValue$$]}, {0, -2}], 
            Inset[
             Framed[
              Pane[
              "The curve approaches its tangent as we zoom in on \
\!\(TraditionalForm\`P\).", {
               120, Automatic}, $CellContext`bcPBS], $CellContext`bcFO, 
              Background -> White], 
             Scaled[{0.5, 0.98}], {Center, Top}], 
            Table[{
              GrayLevel[$CellContext`i/10], 
              
              Line[{{$CellContext`xValue$$ - 
                 10^(-$CellContext`i), \
$CellContext`funcC4F59a[$CellContext`xValue$$] - 
                 10^(-$CellContext`i)}, {$CellContext`xValue$$ - 
                 10^(-$CellContext`i), \
$CellContext`funcC4F59a[$CellContext`xValue$$] + 
                 10^(-$CellContext`i)}, {$CellContext`xValue$$ + 
                 10^(-$CellContext`i), \
$CellContext`funcC4F59a[$CellContext`xValue$$] + 
                 10^(-$CellContext`i)}, {$CellContext`xValue$$ + 
                 10^(-$CellContext`i), \
$CellContext`funcC4F59a[$CellContext`xValue$$] - 
                 10^(-$CellContext`i)}, {$CellContext`xValue$$ - 
                 10^(-$CellContext`i), \
$CellContext`funcC4F59a[$CellContext`xValue$$] - 
                 10^(-$CellContext`i)}}]}, {$CellContext`i, 1, 3}]}]}, 
         Method -> {"AxesInFront" -> False}, ImageSize -> 4 72, AspectRatio -> 
         1, PlotRange -> 
         If[$CellContext`zoomLevel$$ == 0, {{-2, 2}, {-2, 
           2}}, {{$CellContext`xValue$$ - 
             10^((-$CellContext`zoomLevel$$)/2), $CellContext`xValue$$ + 
             10^((-$CellContext`zoomLevel$$)/
               2)}, {$CellContext`funcC4F59a[$CellContext`xValue$$] - 
             10^((-$CellContext`zoomLevel$$)/
              2), $CellContext`funcC4F59a[$CellContext`xValue$$] + 
             10^((-$CellContext`zoomLevel$$)/2)}}], Frame -> True, 
         BaseStyle -> {"Text", 13}, FrameTicks -> {{{{
              $CellContext`funcC4F59a[-0.1], 
              "\!\(TraditionalForm\`f(a)\)"}, {
              $CellContext`funcC4F59a[0.6], "\!\(TraditionalForm\`f(b)\)"}, {
              $CellContext`funcC4F59a[1.6], "\!\(TraditionalForm\`f(c)\)"}}, 
            None}, {{{-0.1, "\!\(TraditionalForm\`a\)"}, {
             0.6, "\!\(TraditionalForm\`b\)"}, {
             1.6, "\!\(TraditionalForm\`c\)"}}, None}}], 
       "Specifications" :> {
        "Location of point \!\(\*\nStyleBox[\"P\",\n\
FontSlant->\"Italic\"]\)", {{$CellContext`xValue$$, -0.1, ""}, {-0.1 -> 
           Pane["\!\(TraditionalForm\`x = a\)", {48, Automatic}, Alignment -> 
             Center], 0.6 -> 
           Pane["\!\(TraditionalForm\`x = b\)", {48, Automatic}, Alignment -> 
             Center], 1.6 -> 
           Pane["\!\(TraditionalForm\`x = c\)", {48, Automatic}, Alignment -> 
             Center]}, ControlType -> SetterBar, Appearance -> "Vertical"}, 
         Delimiter, 
         "Zoom in to \!\(\*\nStyleBox[\"P\",\nFontSlant->\"Italic\"]\)", \
{{$CellContext`zoomLevel$$, 0, ""}, 0, 5, ControlType -> Trigger, 
          DefaultDuration -> 5, 
          AppearanceElements -> {
           "PlayPauseButton", "StepLeftButton", "StepRightButton"}}}, 
       "Options" :> {
        ControlPlacement -> Left, LabelStyle -> 11, Paneled -> False, 
         Deployed -> True, AppearanceElements -> "ResetButton"}, 
       "DefaultOptions" :> {}],
      ImageSizeCache->{416., {154., 160.}},
      SingleEvaluation->True],
     Deinitialization:>None,
     DynamicModuleValues:>{},
     Initialization:>({{$CellContext`staticPlotC4F59a = Graphics[{{{}, {}, {
               Hue[0.67, 0.6, 0.6], 
               Thickness[Large], 
               GrayLevel[0], 
               Line[CompressedData["
1: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
                
                "]]}}}, {
            AspectRatio -> GoldenRatio^(-1), Axes -> True, 
             AxesOrigin -> {0, 0}, 
             PlotRange -> {{-2, 2}, {-1.9571362458690313`, 
               1.9571342789544488`}}, PlotRangeClipping -> True, 
             PlotRangePadding -> {
               Scaled[0.02], 
               Scaled[0.02]}}], Attributes[PlotRange] = {ReadProtected}, 
          Attributes[Derivative] = {
           NHoldAll, ReadProtected}, $CellContext`funcC4F59a[
            Pattern[$CellContext`x, 
             Blank[]]] := $CellContext`x 
           Cos[((Pi/2) $CellContext`x)^2], $CellContext`bcR = 
          RGBColor[0.8, 0, 0.4], $CellContext`bcPBS = 
          BaseStyle -> {
            LineIndent -> 0, LinebreakAdjustments -> {1, 1, 0, 0, 0}, 
             LineBreakWithin -> Automatic, Hyphenation -> True, TextAlignment -> 
             Left, FontSize -> 13}, $CellContext`bcFO = {
           RoundingRadius -> 5, FrameStyle -> GrayLevel[0.85]}}; {
          Graphics[{{{}, {}, {
              Hue[0.67, 0.6, 0.6], 
              Thickness[Large], 
              GrayLevel[0], 
              Line[CompressedData["
1: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
               
               "]]}}}, {
           AspectRatio -> GoldenRatio^(-1), Axes -> True, 
            AxesOrigin -> {0, 0}, 
            PlotRange -> {{-2, 2}, {-1.9571362458690313`, 
              1.9571342789544488`}}, PlotRangeClipping -> True, 
            PlotRangePadding -> {
              Scaled[0.02], 
              Scaled[0.02]}}]}}; Typeset`initDone$$ = True),
     SynchronousInitialization->True,
     UnsavedVariables:>{Typeset`initDone$$},
     UntrackedVariables:>{Typeset`size$$}], "Manipulate",
    Deployed->True,
    StripOnInput->False],
   Manipulate`InterpretManipulate[1]],
  FrameStyle->GrayLevel[0.95],
  RoundingRadius->5,
  StripOnInput->False]], "Output"]
},
Saveable->False,
WindowSize->{1024, 720},
WindowMargins->{{5, Automatic}, {Automatic, 5}},
WindowTitle->"Section 4.5, Figure 4.59a",
DockedCells->Cell[
  RawBoxes[
   TagBox[
    GridBox[{{
       PaneBox[
       "\"P\[VeryThinSpace]E\[VeryThinSpace]A\[VeryThinSpace]R\[VeryThinSpace]\
S\[VeryThinSpace]O\[VeryThinSpace]N\"", 
        BaseStyle -> {
         FontColor -> GrayLevel[0.95], FontFamily -> "SR", FontSize -> 12, 
          Background -> 
          RGBColor[
           0.21568627450980393`, 0.27450980392156865`, 0.5764705882352941]}, 
        Alignment -> Center, ImageSize -> {70, 30}], 
       InterpretationBox[
        StyleBox[
         GraphicsBox[{}, ImageSize -> {3, 0}, BaselinePosition -> Baseline], 
         "CacheGraphics" -> False], 
        Spacer[3]], 
       PaneBox[
        StyleBox[
         TagBox[
          GridBox[{{
             StyleBox["\"CALCULUS\"", "SR", Bold, 14, StripOnInput -> False], 
             
             StyleBox[
             "\" Early Transcendentals\"", "SR", 11, StripOnInput -> False]}, {
             StyleBox["\"2nd Edition\"", "SR", 11, StripOnInput -> False], 
             ""}}, GridBoxAlignment -> {"Columns" -> {{Left}}}, AutoDelete -> 
           False, GridBoxItemSize -> {
            "Columns" -> {{Automatic}}, "Rows" -> {{Automatic}}}, 
           GridBoxSpacings -> {"Columns" -> {{0}}}], "Grid"], Bold, 
         StripOnInput -> False], Alignment -> {Left, Center}, 
        BaselinePosition -> Center, ImageSize -> {251, 30}], 
       InterpretationBox[
        StyleBox[
         GraphicsBox[{}, ImageSize -> {
            Dynamic[
             Max[0, First[
                ReplaceAll[WindowSize, 
                 Options[
                  EvaluationNotebook[], WindowSize]]] - 562]], 0}, 
          BaselinePosition -> Baseline], "CacheGraphics" -> False], 
        Spacer[
         Dynamic[
          Max[0, First[
             ReplaceAll[WindowSize, 
              Options[
               EvaluationNotebook[], WindowSize]]] - 562]]]], 
       PaneBox[
        TagBox[
         GridBox[{{"\"Section \"", "\"4.5\"", 
            
            TemplateBox[{"\", Figure \"", "\"4\"", "\".\""}, "Row", 
             DisplayFunction -> (
              RowBox[{#, "\[InvisibleSpace]", #2, 
                "\[InvisibleSpace]", #3}]& ), 
             InterpretationFunction -> (RowBox[{"Row", "[", 
                RowBox[{"{", 
                  RowBox[{#, ",", #2, ",", #3}], "}"}], "]"}]& )], 
            "\"59a\""}}, GridBoxAlignment -> {"Columns" -> {{Left}}}, 
          AutoDelete -> False, 
          GridBoxItemSize -> {
           "Columns" -> {{Automatic}}, "Rows" -> {{Automatic}}}, 
          GridBoxSpacings -> {"Columns" -> {{0}}}, BaseStyle -> {"SR", 13}], 
         "Grid"], Alignment -> {Right, Center}, BaselinePosition -> Center, 
        ImageSize -> {175, 22}], 
       InterpretationBox[
        StyleBox[
         GraphicsBox[{}, ImageSize -> {6, 0}, BaselinePosition -> Baseline], 
         "CacheGraphics" -> False], 
        Spacer[6]], 
       ActionMenuBox[
        StyleBox["\"%\"", "Label", 13, StripOnInput -> False], {
        "\"50%\"" :> {
           SetOptions[
            ButtonNotebook[], Magnification -> 0.5]}, "\"75%\"" :> {
           SetOptions[
            ButtonNotebook[], Magnification -> 0.75]}, "\"100%\"" :> {
           SetOptions[
            ButtonNotebook[], Magnification -> 1]}, "\"125%\"" :> {
           SetOptions[
            ButtonNotebook[], Magnification -> 1.25]}, "\"150%\"" :> {
           SetOptions[
            ButtonNotebook[], Magnification -> 1.5]}, "\"175%\"" :> {
           SetOptions[
            ButtonNotebook[], Magnification -> 1.75]}, "\"200%\"" :> {
           SetOptions[
            ButtonNotebook[], Magnification -> 2]}, "\"225%\"" :> {
           SetOptions[
            ButtonNotebook[], Magnification -> 2.25]}, "\"250%\"" :> {
           SetOptions[
            ButtonNotebook[], Magnification -> 2.5]}, "\"275%\"" :> {
           SetOptions[
            ButtonNotebook[], Magnification -> 2.75]}, "\"300%\"" :> {
           SetOptions[
            ButtonNotebook[], Magnification -> 3]}}, 
        FrameMargins -> {{0, 1}, {0, 0}}, ImageMargins -> 0, 
        ImageSize -> {40, 22}, BaselinePosition -> Center]}}, 
     GridBoxAlignment -> {"Columns" -> {{Left}}, "Rows" -> {{Center}}}, 
     AutoDelete -> False, 
     GridBoxItemSize -> {"Columns" -> {{Automatic}}, "Rows" -> {{Automatic}}},
      GridBoxSpacings -> {"Columns" -> {{0}}}], "Grid"]], "DockedCell", 
  CellFrameMargins -> 3],
PageHeaders->{{
   Cell[
    TextData[
     RowBox[{
       RowBox[{"CALCULUS", "  ", 
         StyleBox["Early Transcendentals", Smaller]}]}]], "Header"], "", 
   Cell[
    TextData["Section 4.5, Figure 4.59a"], "Header"]}, {
   Cell[
    TextData["Section 4.5, Figure 4.59a"], "Header"], "", 
   Cell[
    TextData[
     RowBox[{
       RowBox[{"CALCULUS", "  ", 
         StyleBox["Early Transcendentals", Smaller]}]}]], "Header"]}},
PageFooters->{{"", 
   Cell[
    TextData["Copyright \[Copyright] 2014 Pearson Education, Inc."], 
    "Footer"], ""}, {"", 
   Cell[
    TextData["Copyright \[Copyright] 2014 Pearson Education, Inc."], 
    "Footer"], ""}},
PrintingOptions->{"FacingPages"->False,
"FirstPageHeader"->True,
"PaperOrientation"->"Landscape"},
ShowCellBracket->Automatic,
Deployed->False,
ShowCellTags->False,
Magnification->1,
FrontEndVersion->"8.0 for Mac OS X x86 (32-bit, 64-bit Kernel) (October 6, \
2011)",
StyleDefinitions->Notebook[{
   Cell[
    StyleData[StyleDefinitions -> "Default.nb"]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Section"], CellFrame -> {{0, 0}, {0.5, 0}}, ShowGroupOpener -> 
       False, CellMargins -> {{10, 0}, {3, 10}}, CellFrameColor -> 
       GrayLevel[0.85], FontFamily -> "Helvetica", FontSize -> 20, FontWeight -> 
       "Bold", FontSlant -> "Plain", FontColor -> GrayLevel[0]], 
      Cell[
       StyleData["Section", "Printout"], CellFrame -> None, ShowGroupOpener -> 
       False, CellMargins -> {{0, Inherited}, {3, 10}}, CellFrameColor -> 
       GrayLevel[0.5], FontFamily -> "Helvetica", FontSize -> 18, FontWeight -> 
       "Bold", FontSlant -> "Plain", FontTracking -> "Wide"]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Subsection"], CellFrame -> {{0.5, 0}, {0, 0.5}}, 
       CellDingbat -> None, ShowGroupOpener -> True, 
       CellMargins -> {{15, 0}, {2, 5}}, CellFrameColor -> GrayLevel[0.85], 
       FontFamily -> "Helvetica", FontSize -> 18, FontWeight -> "Bold", 
       FontSlant -> "Plain", FontColor -> GrayLevel[0]], 
      Cell[
       StyleData["Subsection", "Printout"], CellFrame -> None, CellDingbat -> 
       None, ShowGroupOpener -> True, CellMargins -> {{0, 0}, {2, 10}}, 
       CellFrameColor -> GrayLevel[0.85], FontFamily -> "Helvetica", FontSize -> 
       16, FontWeight -> "Bold", FontSlant -> "Plain"]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Subsubsection"], CellDingbat -> None, ShowGroupOpener -> 
       True, CellMargins -> {{30, Inherited}, {2, 10}}, FontFamily -> 
       "Helvetica", FontSize -> 14, FontWeight -> "Bold", FontColor -> 
       GrayLevel[0]], 
      Cell[
       StyleData["Subsubsection", "Printout"], CellDingbat -> None, 
       CellMargins -> {{0, Inherited}, {2, 10}}, FontFamily -> "Helvetica", 
       FontSize -> 13]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Subsubsubsection"], CellDingbat -> None, ShowGroupOpener -> 
       True, CellMargins -> {{30, Inherited}, {2, 10}}, FontFamily -> 
       "Helvetica", FontSize -> 14, FontWeight -> "Bold", FontSlant -> 
       "Plain", FontColor -> GrayLevel[0]], 
      Cell[
       StyleData["Subsubsubsection", "Printout"], CellDingbat -> None, 
       ShowGroupOpener -> True, CellMargins -> {{0, Inherited}, {2, 10}}, 
       FontFamily -> "Helvetica", FontSize -> 13, FontSlant -> "Plain"]}, 
     Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Subsubsubsubsection"], CellDingbat -> None, ShowGroupOpener -> 
       True, CellMargins -> {{30, Inherited}, {2, 10}}, FontFamily -> 
       "Helvetica", FontSize -> 14, FontWeight -> "Bold", FontColor -> 
       GrayLevel[0]], 
      Cell[
       StyleData["Subsubsubsubsection", "Printout"], CellDingbat -> None, 
       ShowGroupOpener -> True, CellMargins -> {{0, Inherited}, {2, 10}}, 
       FontFamily -> "Helvetica", FontSize -> 13]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["FirstCell"], ShowCellBracket -> False, 
       CellMargins -> {{30, 10}, {7, 7}}, CellOpen -> False, TabSpacings -> 3,
        FontSize -> 14], 
      Cell[
       StyleData["FirstCell", "Printout"], CellMargins -> {{30, 10}, {7, 7}}, 
       CellOpen -> False, FontSize -> 13]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Text"], CellMargins -> {{30, 10}, {7, 7}}, TabSpacings -> 3,
        FontFamily -> "Times", FontSize -> 14], 
      Cell[
       StyleData["Text", "Printout"], CellMargins -> {{0, 0}, {7, 7}}, 
       TabSpacings -> 3, FontFamily -> "Times", FontSize -> 13]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Item"], CellDingbat -> 
       Cell["\[FilledSmallCircle]", FontWeight -> "Bold"], 
       CellMargins -> {{50, 10}, {4, 4}}, 
       CellGroupingRules -> {"GroupTogetherNestedGrouping", 15000}, 
       CellFrameLabelMargins -> 4, DefaultNewCellStyle -> "Item", TabSpacings -> 
       3, CounterIncrements -> "Item", 
       CounterAssignments -> {{"Subitem", 0}, {"Subsubitem", 0}}, FontFamily -> 
       "Times", FontSize -> 14], 
      Cell[
       StyleData["Item", "Printout"], CellDingbat -> 
       Cell["\[FilledSmallCircle]", FontWeight -> "Bold"], 
       CellMargins -> {{20, 0}, {2, 2}}, CellFrameLabelMargins -> 4, 
       TabSpacings -> 3, FontSize -> 13]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Subitem"], CellDingbat -> 
       Cell["\[FilledSmallCircle]", FontWeight -> "Bold"], 
       CellMargins -> {{70, 12}, {4, 4}}, 
       CellGroupingRules -> {"GroupTogetherNestedGrouping", 15100}, 
       CellFrameLabelMargins -> 4, DefaultNewCellStyle -> "Item", TabSpacings -> 
       3, CounterIncrements -> "Subitem", 
       CounterAssignments -> {{"Subsubitem", 0}}, FontFamily -> "Times", 
       FontSize -> 14, FontWeight -> "Plain", FontSlant -> "Plain"], 
      Cell[
       StyleData["Subitem", "Printout"], CellDingbat -> 
       Cell["\[FilledSmallCircle]", FontWeight -> "Bold"], 
       CellMargins -> {{40, 2}, {1, 1}}, CellFrameLabelMargins -> 4, 
       TabSpacings -> 3, FontSize -> 13]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Subsubitem"], CellDingbat -> 
       Cell["\[FilledSmallCircle]", FontWeight -> "Bold"], 
       CellMargins -> {{90, 12}, {4, 4}}, 
       CellGroupingRules -> {"GroupTogetherNestedGrouping", 15200}, 
       CellFrameLabelMargins -> 4, DefaultNewCellStyle -> "Subsubitem", 
       TabSpacings -> 3, CounterIncrements -> "Subsubitem", FontFamily -> 
       "Times", FontSize -> 14, FontWeight -> "Plain", FontSlant -> "Plain"], 
      
      Cell[
       StyleData["Subsubitem", "Printout"], CellDingbat -> 
       Cell["\[FilledSmallCircle]", FontWeight -> "Bold"], 
       CellMargins -> {{60, 2}, {1, 1}}, CellFrameLabelMargins -> 4, 
       TabSpacings -> 3, FontSize -> 13]}, Open]], 
   Cell[
    StyleData["QuickCheckFont"], FontFamily -> "Helvetica", FontSize -> 11, 
    FontWeight -> "Bold", FontSlant -> "Plain", FontColor -> GrayLevel[0]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["QuickCheck"], CellMargins -> {{30, 10}, {0, 7}}, 
       CellGroupingRules -> {"GroupTogetherGrouping", 51}, 
       LineSpacing -> {1, 3}, TabSpacings -> 3, FontFamily -> "Times", 
       FontSize -> 14], 
      Cell[
       StyleData["QuickCheck", "Printout"], CellMargins -> {{0, 30}, {0, 7}}, 
       PageBreakWithin -> False, LineSpacing -> {1, 3}, TabSpacings -> 3, 
       FontSize -> 13]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["QuickCheckAnswerIcon"], CellMargins -> {{40, 108}, {0, 0}}, 
       CellGroupingRules -> {"GroupTogetherGrouping", 100000}, CellFrameColor -> 
       RGBColor[0.976, 0.855, 0.514], TextAlignment -> Left, FontSize -> 13], 
      
      Cell[
       StyleData["QuickCheckAnswerIcon", "Printout"], 
       CellMargins -> {{10, 288}, {0, 0}}, PageBreakAbove -> False, 
       PageBreakBelow -> False, CellFrameColor -> 
       RGBColor[0.976, 0.855, 0.514], FontSize -> 13]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["QuickCheckAnswer"], CellFrame -> {{3, 0}, {0, 0}}, 
       CellMargins -> {{60, 60}, {7, 0}}, 
       CellGroupingRules -> {"GroupTogetherGrouping", 100000}, CellFrameColor -> 
       RGBColor[0.976, 0.855, 0.514], LineSpacing -> {1, 0}, 
       ParagraphSpacing -> {0, 6}, FontFamily -> "Times", FontSize -> 14], 
      Cell[
       StyleData["QuickCheckAnswer", "Printout"], 
       CellFrame -> {{3, 0}, {0, 0}}, CellMargins -> {{30, 60}, {7, 0}}, 
       PageBreakWithin -> False, CellFrameColor -> 
       RGBColor[0.976, 0.855, 0.514], LineSpacing -> {1, 0}, 
       ParagraphSpacing -> {0, 6}, FontSize -> 13]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["DefinitionFont"], FontFamily -> "Arial", FontSize -> 14, 
       FontWeight -> "Bold", FontSlant -> "Plain", FontColor -> 
       RGBColor[0.6, 0.408, 0.122]], 
      Cell[
       StyleData["DefinitionFont", "Printout"], FontFamily -> "Arial", 
       FontSize -> 13, FontWeight -> "Bold", FontSlant -> "Plain", FontColor -> 
       GrayLevel[0]]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Definition"], CellFrame -> 1, 
       CellMargins -> {{30, 30}, {7, 7}}, PageBreakWithin -> False, 
       CellFrameColor -> RGBColor[0.6, 0.408, 0.122], LineSpacing -> {1, 3}, 
       ParagraphSpacing -> {0, 6}, TabSpacings -> 3, FontFamily -> "Times", 
       FontSize -> 14], 
      Cell[
       StyleData["Definition", "Printout"], CellFrame -> 1, 
       CellMargins -> {{30, 30}, {7, 7}}, PageBreakWithin -> False, 
       CellFrameColor -> GrayLevel[0.5], LineSpacing -> {1, 3}, 
       ParagraphSpacing -> {0, 6}, TabSpacings -> 3, FontFamily -> "Times", 
       FontSize -> 13]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["TheoremFont"], FontFamily -> "Arial", FontSize -> 14, 
       FontWeight -> "Bold", FontSlant -> "Plain", FontColor -> 
       RGBColor[0, 0.451, 0.592]], 
      Cell[
       StyleData["TheoremFont", "Printout"], FontFamily -> "Arial", FontSize -> 
       13, FontWeight -> "Bold", FontSlant -> "Plain", FontColor -> 
       GrayLevel[0]]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Theorem"], CellFrame -> 1, 
       CellMargins -> {{30, 30}, {7, 7}}, PageBreakWithin -> False, 
       CellFrameColor -> RGBColor[0, 0.451, 0.592], LineSpacing -> {1, 3}, 
       ParagraphSpacing -> {0, 6}, TabSpacings -> 3, FontFamily -> "Times", 
       FontSize -> 14], 
      Cell[
       StyleData["Theorem", "Printout"], CellFrame -> 1, 
       CellMargins -> {{30, 30}, {7, 7}}, PageBreakWithin -> False, 
       CellFrameColor -> GrayLevel[0.5], LineSpacing -> {1, 3}, 
       ParagraphSpacing -> {0, 6}, TabSpacings -> 3, FontFamily -> "Times", 
       FontSize -> 13]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["ProofFont"], FontFamily -> "Helvetica", FontSize -> 14, 
       FontWeight -> "Bold", FontColor -> RGBColor[0., 0.576, 0.816]], 
      Cell[
       StyleData["ProofFont", "Printout"], FontFamily -> "Helvetica", 
       FontSize -> 13, FontWeight -> "Bold", FontColor -> GrayLevel[0]]}, 
     Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["SummaryFont"], FontFamily -> "Arial", FontSize -> 14, 
       FontWeight -> "Bold", FontSlant -> "Plain", FontColor -> 
       RGBColor[0.204, 0.114, 0.396]], 
      Cell[
       StyleData["SummaryFont", "Printout"], FontFamily -> "Arial", FontSize -> 
       13, FontWeight -> "Bold", FontSlant -> "Plain", FontColor -> 
       GrayLevel[0]]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Summary"], CellFrame -> 1, 
       CellMargins -> {{30, 30}, {7, 7}}, PageBreakWithin -> False, 
       CellFrameColor -> RGBColor[0.204, 0.114, 0.396], LineSpacing -> {1, 3},
        ParagraphSpacing -> {0, 6}, TabSpacings -> 3, FontFamily -> "Times", 
       FontSize -> 14], 
      Cell[
       StyleData["Summary", "Printout"], CellFrame -> 1, 
       CellMargins -> {{30, 30}, {7, 7}}, PageBreakWithin -> False, 
       CellFrameColor -> GrayLevel[0.5], LineSpacing -> {1, 3}, 
       ParagraphSpacing -> {0, 6}, TabSpacings -> 3, FontFamily -> "Times", 
       FontSize -> 13]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["ProcedureFont"], FontFamily -> "Arial", FontSize -> 14, 
       FontWeight -> "Bold", FontSlant -> "Plain", FontTracking -> 
       "Condensed", FontColor -> RGBColor[0.204, 0.114, 0.396]], 
      Cell[
       StyleData["ProcedureFont", "Printout"], FontFamily -> "Arial", 
       FontSize -> 13, FontWeight -> "Bold", FontSlant -> "Plain", 
       FontTracking -> "Condensed", FontColor -> GrayLevel[0]]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Procedure"], CellFrame -> 1, 
       CellMargins -> {{30, 30}, {7, 7}}, CellFrameColor -> 
       RGBColor[0.204, 0.114, 0.396], LineSpacing -> {1, 3}, 
       ParagraphSpacing -> {0, 6}, TabSpacings -> 3, FontFamily -> "Times", 
       FontSize -> 14], 
      Cell[
       StyleData["Procedure", "Printout"], CellFrame -> 1, 
       CellMargins -> {{30, 30}, {7, 7}}, PageBreakWithin -> False, 
       CellFrameColor -> GrayLevel[0.5], LineSpacing -> {1, 3}, 
       ParagraphSpacing -> {0, 6}, TabSpacings -> 3, FontFamily -> "Times", 
       FontSize -> 13]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Important"], CellFrame -> 1, 
       CellMargins -> {{30, 30}, {7, 7}}, PageBreakWithin -> False, 
       CellFrameColor -> RGBColor[0.204, 0.114, 0.396], LineSpacing -> {1, 3},
        ParagraphSpacing -> {0, 6}, TabSpacings -> 3, FontFamily -> "Times", 
       FontSize -> 14], 
      Cell[
       StyleData["Important", "Printout"], CellFrame -> 1, 
       CellMargins -> {{30, 30}, {7, 7}}, PageBreakWithin -> False, 
       CellFrameColor -> GrayLevel[0.5], LineSpacing -> {1, 3}, 
       ParagraphSpacing -> {0, 6}, TabSpacings -> 3, FontFamily -> "Times", 
       FontSize -> 13]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["RelatedExercises"], TextAlignment -> Right, FontFamily -> 
       "Helvetica", FontSize -> 13, FontColor -> RGBColor[0.796, 0, 0.42]], 
      Cell[
       StyleData["RelatedExercises", "Printout"], TextAlignment -> Right, 
       FontFamily -> "Helvetica", FontSize -> 13, FontColor -> GrayLevel[0]]},
      Open]], 
   Cell[
    StyleData["CalloutIcon"], CellMargins -> {{30, 108}, {0, 0}}, 
    CellGroupingRules -> {"GroupTogetherGrouping", 100000}, CellFrameColor -> 
    RGBColor[0.976, 0.855, 0.514], TextAlignment -> Left, 
    LineSpacing -> {1, 2}, FontSize -> 13], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["CalloutIconFont"], FontFamily -> "Helvetica", FontSize -> 
       13, FontTracking -> "Wide", FontColor -> RGBColor[0.68, 0.57, 0.34]], 
      Cell[
       StyleData["CalloutIconFont", "Printout"], FontFamily -> "Helvetica", 
       FontSize -> 12, FontColor -> GrayLevel[0]]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Callout"], CellFrame -> 1, 
       CellMargins -> {{30, 108}, {2, 0}}, 
       CellGroupingRules -> {"GroupTogetherGrouping", 100000}, CellFrameColor -> 
       RGBColor[0.976, 0.855, 0.514], LineSpacing -> {1, 2}, 
       ParagraphSpacing -> {0, 6}, FontFamily -> "Times", FontSize -> 13], 
      Cell[
       StyleData["Callout", "Printout"], CellFrame -> {{1, 0}, {0, 0}}, 
       CellMargins -> {{30, 180}, {2, 0}}, PageBreakWithin -> False, 
       CellFrameColor -> GrayLevel[0.5], LineSpacing -> {1, 2}, 
       ParagraphSpacing -> {0, 6}, FontSize -> 12]}, Open]], 
   Cell[
    StyleData["FigureCaption"], CellMargins -> {{30, 30}, {7, 7}}, 
    LineSpacing -> {1, 3}, FontSize -> 14], 
   Cell[
    StyleData["TableFont"], FontFamily -> "Arial", FontSize -> 13, FontWeight -> 
    "Bold", FontColor -> GrayLevel[0]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["TableCell"], CellMargins -> {{30, 10}, {5, 5}}], 
      Cell[
       StyleData["TableCell", "Printout"], CellMargins -> {{0, 0}, {5, 5}}]}, 
     Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Note"], FontFamily -> "Helvetica", FontSize -> 12, 
       FontTracking -> "Wide", FontColor -> RGBColor[0.6, 0.4, 0.4]], 
      Cell[
       StyleData["Note", "Printout"], FontFamily -> "Helvetica", FontSize -> 
       12, FontTracking -> "Wide", FontColor -> GrayLevel[0]]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["SectionTitleFont"], FontFamily -> "Helvetica", FontWeight -> 
       "Bold", FontTracking -> "Extended", FontColor -> 
       RGBColor[0.8, 0, 0.4]], 
      Cell[
       StyleData["SectionTitleFont", "Printout"], FontFamily -> "Helvetica", 
       FontWeight -> "Bold", FontTracking -> "Extended", FontColor -> 
       GrayLevel[0]]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["TypesetAnnotationFont"], FontFamily -> "Times", FontColor -> 
       RGBColor[0, 0.576, 0.816]], 
      Cell[
       StyleData["TypesetAnnotationFont", "Printout"], FontFamily -> "Times", 
       FontColor -> GrayLevel[0]]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["ExampleFont"], FontFamily -> "Helvetica", FontColor -> 
       RGBColor[0, 0.576, 0.816]], 
      Cell[
       StyleData["ExampleFont", "Printout"], FontFamily -> "Helvetica", 
       FontColor -> GrayLevel[0]]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["SolutionFont"], FontFamily -> "Helvetica", FontColor -> 
       RGBColor[0.796, 0, 0.42]], 
      Cell[
       StyleData["SolutionFont", "Printout"], FontFamily -> "Helvetica", 
       FontColor -> GrayLevel[0]]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["ExerciseFont"], FontFamily -> "Helvetica", FontColor -> 
       RGBColor[0.8, 0, 0.4]], 
      Cell[
       StyleData["ExerciseFont", "Printout"], FontFamily -> "Helvetica", 
       FontColor -> GrayLevel[0]]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["ExerciseGroupFont"], FontFamily -> "Helvetica", FontColor -> 
       RGBColor[0, 0.576, 0.816]], 
      Cell[
       StyleData["ExerciseGroupFont", "Printout"], FontFamily -> "Helvetica", 
       FontColor -> GrayLevel[0]]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["ExerciseAnswerGroupFont"], FontFamily -> "Helvetica", 
       FontColor -> GrayLevel[0.5]], 
      Cell[
       StyleData["ExerciseAnswerGroupFont", "Printout"], FontFamily -> 
       "Helvetica", FontColor -> GrayLevel[0]]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["ControlFont"], FontFamily -> "Helvetica", FontSize -> 12, 
       FontTracking -> "Wide", FontColor -> GrayLevel[0.4]], 
      Cell[
       StyleData["ControlFont", "Printout"], FontFamily -> "Helvetica", 
       FontSize -> 12, FontTracking -> "Wide", FontColor -> GrayLevel[0]]}, 
     Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["FigureFont"], FontFamily -> "Arial", FontSize -> 13, 
       FontWeight -> "Bold", FontColor -> RGBColor[0., 0.576, 0.816]], 
      Cell[
       StyleData["FigureFont", "Printout"], FontFamily -> "Arial", FontSize -> 
       13, FontWeight -> "Bold", FontColor -> GrayLevel[0]]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["FigureFontText"], FontFamily -> "Times", FontColor -> 
       RGBColor[0., 0.576, 0.816]], 
      Cell[
       StyleData["FigureFontText", "Printout"], FontFamily -> "Times", 
       FontColor -> GrayLevel[0]]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["ExerciseDirectionsCell"], CellMargins -> {{30, 10}, {7, 7}},
        PageBreakWithin -> False, LineSpacing -> {1, 3}, TabSpacings -> 2, 
       FontFamily -> "Times", FontSize -> 14, FontWeight -> "Plain", 
       FontSlant -> "Italic"], 
      Cell[
       StyleData["ExerciseDirectionsCell", "Printout"], 
       CellMargins -> {{30, 10}, {7, 7}}, PageBreakWithin -> False, 
       LineSpacing -> {1, 3}, TabSpacings -> 2, FontFamily -> "Times", 
       FontSize -> 13, FontWeight -> "Plain", FontSlant -> "Italic"]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["TExerciseDirectionsCell"], 
       CellMargins -> {{10, 10}, {7, 7}}, PageBreakWithin -> False, 
       LineSpacing -> {1, 3}, ParagraphIndent -> -15, TabSpacings -> 2, 
       FontFamily -> "Times", FontSize -> 14, FontWeight -> "Plain", 
       FontSlant -> "Italic"], 
      Cell[
       StyleData["TExerciseDirectionsCell", "Printout"], 
       CellMargins -> {{10, 10}, {7, 7}}, PageBreakWithin -> False, 
       LineSpacing -> {1, 3}, ParagraphIndent -> -15, TabSpacings -> 2, 
       FontFamily -> "Times", FontSize -> 13, FontWeight -> "Plain", 
       FontSlant -> "Italic"]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["SubExerciseDirectionsCell"], 
       CellMargins -> {{58, 10}, {2, 2}}, PageBreakWithin -> False, 
       LineSpacing -> {1, 3}, ParagraphIndent -> -22, TabSpacings -> 2, 
       FontFamily -> "Times", FontSize -> 14, FontWeight -> "Plain", 
       FontSlant -> "Italic"], 
      Cell[
       StyleData["SubExerciseDirectionsCell", "Printout"], 
       CellMargins -> {{58, 10}, {2, 2}}, PageBreakWithin -> False, 
       LineSpacing -> {1, 3}, ParagraphIndent -> -16, TabSpacings -> 2, 
       FontFamily -> "Times", FontSize -> 13, FontWeight -> "Plain", 
       FontSlant -> "Italic"]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Problem"], CellMargins -> {{30, 10}, {7, 7}}, 
       PageBreakWithin -> False, LineSpacing -> {1, 3}, 
       ParagraphSpacing -> {0, 3}, ParagraphIndent -> -29, TabSpacings -> 2.5,
        FontFamily -> "Times", FontSize -> 14], 
      Cell[
       StyleData["Problem", "Printout"], CellMargins -> {{30, 10}, {7, 7}}, 
       PageBreakWithin -> False, LineSpacing -> {1, 3}, 
       ParagraphSpacing -> {0, 3}, ParagraphIndent -> -19, TabSpacings -> 2.5,
        FontSize -> 13]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["TProblem"], CellMargins -> {{10, 10}, {7, 7}}, 
       PageBreakWithin -> False, LineSpacing -> {1, 3}, 
       ParagraphSpacing -> {0, 3}, ParagraphIndent -> -47, TabSpacings -> 2, 
       FontFamily -> "Times", FontSize -> 14], 
      Cell[
       StyleData["TProblem", "Printout"], CellMargins -> {{10, 10}, {7, 7}}, 
       PageBreakWithin -> False, LineSpacing -> {1, 3}, 
       ParagraphSpacing -> {0, 3}, ParagraphIndent -> -32, TabSpacings -> 2, 
       FontSize -> 13]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["SubProblem"], CellMargins -> {{58, 10}, {2, 2}}, 
       PageBreakWithin -> False, LineSpacing -> {1, 3}, 
       ParagraphIndent -> -22, TabSpacings -> 2, FontFamily -> "Times", 
       FontSize -> 14], 
      Cell[
       StyleData["SubProblem", "Printout"], CellMargins -> {{58, 10}, {2, 2}},
        PageBreakWithin -> False, LineSpacing -> {1, 3}, 
       ParagraphIndent -> -16, TabSpacings -> 2, FontSize -> 13]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Comment"], CellFrame -> {{3, 0}, {0, 0}}, 
       CellMargins -> {{30, 30}, {-1, -1}}, 
       CellElementSpacings -> {"ClosedCellHeight" -> 0}, CellFrameColor -> 
       RGBColor[0, 0, 1], LineSpacing -> {1, 3}, FontSize -> 14, Background -> 
       RGBColor[0.87, 0.94, 1]], 
      Cell[
       StyleData["Comment", "Printout"], CellFrame -> {{3, 0}, {0, 0}}, 
       CellMargins -> {{30, 30}, {-1, -1}}, 
       CellElementSpacings -> {"ClosedCellHeight" -> 0}, 
       LineSpacing -> {1, 3}, FontSize -> 13, Background -> GrayLevel[0.9]]}, 
     Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["EditorComment"], CellFrame -> {{3, 0}, {0, 0}}, 
       CellMargins -> {{30, 30}, {-1, -1}}, 
       CellElementSpacings -> {"ClosedCellHeight" -> 0}, CellFrameColor -> 
       RGBColor[1, 0, 0], LineSpacing -> {1, 3}, FontSize -> 14, Background -> 
       RGBColor[1, 0.85, 0.85]], 
      Cell[
       StyleData["EditorComment", "Printout"], CellFrame -> {{3, 0}, {0, 0}}, 
       CellMargins -> {{30, 30}, {-1, -1}}, 
       CellElementSpacings -> {"ClosedCellHeight" -> 0}, 
       LineSpacing -> {1, 3}, FontSize -> 13, Background -> GrayLevel[0.9]]}, 
     Open]], 
   Cell[
    StyleData["IndexEntry"], CellFrame -> 1, 
    CellMargins -> {{50, 400}, {-1, -1}}, 
    CellElementSpacings -> {"ClosedCellHeight" -> 0}, CellFrameMargins -> 2, 
    CellFrameColor -> GrayLevel[0], LineSpacing -> {1, 3}, FontFamily -> 
    "Verdana", FontSize -> 11, FontColor -> GrayLevel[1], Background -> 
    RGBColor[1, 0.5, 0]], 
   Cell[
    StyleData["ApplicationIndexEntry"], CellFrame -> 1, 
    CellMargins -> {{50, 400}, {-1, -1}}, 
    CellElementSpacings -> {"ClosedCellHeight" -> 0}, CellFrameMargins -> 2, 
    CellFrameColor -> GrayLevel[0], LineSpacing -> {1, 3}, FontFamily -> 
    "Verdana", FontSize -> 11, FontColor -> GrayLevel[1], Background -> 
    RGBColor[0, 0.5, 1]], 
   Cell[
    StyleData["InlineCell"], ScriptSizeMultipliers -> 0.8, ScriptLevel -> 0, 
    NumberSeparator -> ","], 
   Cell[
    StyleData["Output"], NumberSeparator -> ","], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Objectives"], CellFrame -> {{0, 0}, {0, 0}}, 
       CellMargins -> {{30, 30}, {18, -2}}, PageBreakWithin -> False, 
       CellFrameColor -> GrayLevel[0.5], LineSpacing -> {1, 3}, 
       ParagraphSpacing -> {0, 4}, ParagraphIndent -> -24, TabSpacings -> 2, 
       FontFamily -> "Times", FontSize -> 14, Background -> GrayLevel[0.97]], 
      
      Cell[
       StyleData["Objectives", "Printout"], CellMargins -> {{30, 30}, {6, 6}},
        PageBreakWithin -> False, CellFrameColor -> GrayLevel[0.5], 
       ParagraphIndent -> -15, TabSpacings -> 2, FontSize -> 13, Background -> 
       GrayLevel[1]]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Solution"], CellFrame -> {{1, 1}, {0, 1}}, 
       CellMargins -> {{60, 30}, {-1, -1}}, 
       CellElementSpacings -> {"ClosedCellHeight" -> 0}, 
       LineSpacing -> {1, 3}, ParagraphSpacing -> {0, 3}, FontFamily -> 
       "Times", FontSize -> 14, Background -> RGBColor[0.94, 0.91, 0.88]], 
      Cell[
       StyleData["Solution", "Printout"], CellFrame -> {{1, 1}, {0, 1}}, 
       CellMargins -> {{60, 30}, {-1, -1}}, 
       CellElementSpacings -> {"ClosedCellHeight" -> 0}, 
       LineSpacing -> {1, 3}, ParagraphSpacing -> {0, 3}, FontFamily -> 
       "Times", FontSize -> 13, Background -> GrayLevel[1]]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Answer"], CellFrame -> {{1, 1}, {1, 0}}, 
       CellMargins -> {{60, 30}, {-1, -1}}, 
       CellElementSpacings -> {"ClosedCellHeight" -> 0}, 
       LineSpacing -> {1, 3}, ParagraphSpacing -> {0, 3}, FontFamily -> 
       "Times", FontSize -> 14, Background -> GrayLevel[0.95]], 
      Cell[
       StyleData["Answer", "Printout"], CellFrame -> {{1, 1}, {1, 0}}, 
       CellMargins -> {{60, 30}, {-1, -1}}, 
       CellElementSpacings -> {"ClosedCellHeight" -> 0}, 
       LineSpacing -> {1, 3}, ParagraphSpacing -> {0, 3}, FontFamily -> 
       "Times", FontSize -> 13, Background -> GrayLevel[1]]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Hyperlink", StyleDefinitions -> StyleData["Link"]], 
       ContextMenu -> FEPrivate`FrontEndResource["ContextMenus", "Hyperlink"],
        FontColor -> RGBColor[0.269993, 0.308507, 0.6], 
       ButtonBoxOptions -> {ButtonFunction :> (FrontEndExecute[{
            NotebookLocate[#2, "OpenInNewWindow" -> True]}]& ), Evaluator -> 
         None, Method -> "Queued"}], 
      Cell[
       StyleData["Hyperlink", "Condensed"], FontSize -> 11]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Header"], CellMargins -> {{0, 0}, {4, 1}}, StyleMenuListing -> 
       None, FontFamily -> "Helvetica", FontSize -> 8, FontSlant -> "Plain"], 
      
      Cell[
       StyleData["Header", "Printout"], CellMargins -> {{0, 0}, {4, 1}}, 
       StyleMenuListing -> None, FontFamily -> "Helvetica", FontSize -> 8, 
       FontSlant -> "Plain"]}, Open]], 
   Cell[
    CellGroupData[{
      Cell[
       StyleData["Footer"], CellMargins -> {{0, 0}, {0, 4}}, StyleMenuListing -> 
       None, FontFamily -> "Helvetica", FontSize -> 8, FontSlant -> "Plain"], 
      
      Cell[
       StyleData["Footer", "Printout"], CellMargins -> {{0, 0}, {0, 4}}, 
       StyleMenuListing -> None, FontFamily -> "Helvetica", FontSize -> 8, 
       FontSlant -> "Plain"]}, Open]]}, Visible -> False, FrontEndVersion -> 
  "8.0 for Mac OS X x86 (32-bit, 64-bit Kernel) (October 6, 2011)", 
  StyleDefinitions -> "PrivateStylesheetFormatting.nb"]
]
(* End of Notebook Content *)

(* Internal cache information *)
(*CellTagsOutline
CellTagsIndex->{}
*)
(*CellTagsIndex
CellTagsIndex->{}
*)
(*NotebookFileOutline
Notebook[{
Cell[1274, 31, 48927, 834, 70, "Output"]
}
]
*)

(* End of internal cache information *)
(* NotebookSignature QKNNt85fk9aQ6LkYyAeB4mVB *)
