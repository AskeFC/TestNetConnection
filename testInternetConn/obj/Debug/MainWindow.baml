   M S B A M L   `   `   `  ����  testInternetConnM8clr-namespace:testInternetConn;assembly=testInternetConntestInternetConn  5   	   !    testInternetConn.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   Dlocal8clr-namespace:testInternetConn;assembly=testInternetConn  5   	   -   5          �Name$  window��5   P    � Title$ Test Internet Connection��5   	   $	��460��6*   $	��620��67    � Topmost .  � 
ResizeMode$ NoResize=�6R    � WindowStartupLocation$ CenterScreen=�6h    � Cursor$ Arrow��6�    J� Opacity$	 0.8Q�6�    � WindowStyle$ ThreeDBorderWindow=�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5   
   	   
BlurRadius$	 6Q�6   
   ShadowDepth$
 6Q�6*   .��5      � -   5         �Name$ mainGrid��5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��10,10,281,0q�6   $
��Wrap=�6)   $.��(Choose a site to test connection against��6=   $	��Top=�6m   $��51��6�   $��16(�6�   $
��Bold"�6�   $��2��6�    J� IsHitTestVisible .  6�   �� 5   
   $��Website��6   $
��Left=�6"   $��	50,45,0,0q�6=   $	��Top=�6P   $	��118��6h    � ToolTip$' !Choose or enter a website address��6t    .  6�   �� 5   
   -   5         ��Name$ SiteList��5      $��
50,70,50,0q�6%   $	��Top=�69    �� 
IsEditable . $
 Hand��6c   $' !Choose or enter a website address��6q    �� SelectedIndex$ 0��6�   ��. .@�5      �� $��www.Microsoft.com��6   $
��Left=�67   $	��215��6R   �� 5      $��www.Berlios.de��6   $
��Left=�64   $	��215��6O   �� 5      $��www.bbc.co.uk��6   $
��Left=�63   $	��215��6N   �� 5      $��
Google.com��6   $
��Left=�60   $	��215��6K   �� 5      $��
Rambler.ru��6   $
��Left=�60   $	��215��6K   �� 5      $��Sony.jp��6   $
��Left=�6-   $	��215��6H   �� 5      $��DR.dk��6   $
��Left=�6+   $	��215��6F   5      �� 5   
   -   5         ��Name$ 	PingStart��5      $
��Ping��6$   $��30��63   $��107,110,107.5,0q�6?   $	��Top=�6X   $ Start pinging��6�   $
 Hand��6�   $
��Bold"�6�   {�.  ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF475753��6#    � Offset$ 0.502Q�65   � 5       $ 	#FFE5FDF8��6#   $ 1Q�65   � 5!      $ 	#FFE5FDF8��6#   5"      5$      �� 5&   
   -   5         ��Name$ LogBox��5&      $��
10,160,0,0q�6#   $	��Top=�67   $	��104��6O   ���	#FF95AEBD���	#FF303018 � IsSharedSizeScope .  � UseLayoutRounding . $	��Log��6�   $
 Hand��6�    . $ Click to clear the log��6D  .��5'      �� -   5         ��Name$ 
TextOutput��5'      $��1q�6*    �� 
IsReadOnly .  �� TextWrapping$
 Wrap=�6G   ���	#FF000074$��Sylfaen)�6r   $ Arrow��6�   $��Disabled=�6�   $
��Auto=�6�    .  J� 	AllowDrop .  |�.   . ��.  .��6}  ��5(      �� 5)      $
 0,20&�6*    � MappingMode$ Absolute=�6:   $	 0,0&�6Q   .��5*      � $ 	#FFABADB3��6'   $
 0.05Q�69   � 5+      $ 	#FFE2E3EA��6'   $
 0.07Q�69   � 5,      $ Black��6'   $ 1Q�65   5-      .��5.   '   ��5/      �� 50      $ 0.5,1&�6*   $ RelativeToBoundingBox=�6;   $ 0.5,0&�6_   .��51      � $ 	#FF7C7C7C��6'   $ 1Q�69   � 52      $ White��6'   � 53      $ 	#FFFFFCE7��6'   $ 0.551Q�69   � 54      $ 	#FF888886��6'   $ 1Q�69   � 55      $ 	#FF9F9E99��6'   $ 1Q�69   � 56      $ 	#FFA8A7A0��6'   $ 1Q�69   � 57      $ 	#FFBDBBB1��6'   $ 0.989Q�69   58      .��59   &   5:      5;      �� 5=   
   $��Timeout��6   $��1��6"   $��Right=�62   $��
0,20,123,0q�6N   $	��Top=�6b   $��94��6z   $��Right=�6�   $&  Set milliseconds before time out��6�    .  6�   %  Xceed.Wpf.Toolkit.IntegerUpDown  5>   
   -   5          Name$ TimeOut��5>      �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]    Value$
  2000X�6.   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]!   	Increment$! 1X�6;   "   Maximum$" 10000X�6I   #   Minimum$# 1X�6Y   $��	0,20,10,0q�6e   $ J� RenderTransformOrigin$$ 1.199,-0.611&�6x   $��1��6�   $��Right=�6�   $	��108��6�   $��25��6�   $	��Top=�6�   $&  Set milliseconds before time out��6�   ���	#FFE7FFF9|�. 6;  �� 5?   
   $��Time-to-live��6   $��1��6'   $��Right=�67   $��
0,70,118,0q�6S   $	��Top=�6g   $��96��6   $��Right=�6�   $% Set limit of jumps/routes (Ttl)��6�    .  6�     5@   
   -   5        $	 Ttl��5@      $	  128X�6*   $! 1X�66   $
" 5000X�6D   $# 1X�6S   $��	0,70,10,0q�6_   $$ 1.199,-0.611&�6r   $��1��6�   $��Right=�6�   $	��108��6�   $��25��6�   $	��Top=�6�   $% Set limit of jumps/routes (Ttl)��6�   ���	#FFE7FFF9|�. 64  �� 5A   
   -	   5        % ��Name$% Fragmentation��5A      $ ��Allow packet fragmentation��6*   $��1��6O   $��Right=�6_   $��
0,120,10,0q�6{   $	��Top=�6�   $��RightToLeft=�6�   & d� 	IsChecked$
& TrueY�6�   $
 Hand��6�   $) #Allow sent packets to be fragmentet��6�   �� 5B   
   -
   5        $% 	AsyncPing��5B      $��Asynchrounous ping��6&   $��1��6C   $��
0,150,10,0q�6S   $	��Top=�6g   $��RightToLeft=�6   $
& TrueY�6�   $
 Hand��6�   $" Use non-blocking ping method��6�   $��Right=�6�   $	��153��6�   �� 5C   
   -   5        $% VerboseOutput��5C      $�� Verbose output��6*   $��1��6D   $��
0,180,10,0q�6T   $	��Top=�6h   $��RightToLeft=�6�   $��Right=�6�   $	��132��6�   $
 Hand��6�   $" Show more text in StatusText��6�   �� 5D   
   $��Number of times to ping��6   $��1��62   $��84.5,210,69,0q�6B   $	��Top=�6Y   $��28��6q   $ Change amount of pings��6}    .  6�   �� 5E   
   -   5        ' ��Name$' PingAmountTxt��5E      $��1��6Y   $��237.5,210,31,0q�6i   $	��Top=�6�   $��28��6�   $��Right=�6�   $ Amount of pings��6�    .  ��6'   �� *Value+( �� ElementName$( 
PingAmount��6�   �� 5F   
   -   5        ) ��Name$) 
PingAmount��5F      $��1��6%   $��84,240,33,0q�65   $	��Top=�6J   * � Minimum$* 1Q�6b   + �� TickPlacement$+ BottomRight=�6n   , � Value$, 1Q�6�   $ Change amount of pings��6�   $
 Hand��6�   - � SmallChange$- 1Q�6�   . �� IsSnapToTickEnabled. . 6�   �� 5H   
   -   5        $ 	ResultBox��5H      $��Result��6&   $��Disabled=�66   $��2��6j   $��10,280,10,0q�6~   $��94��6�   $	��Top=�6�    .  .��5I      � -   5        $ 
ResultGrid��5I      $��5,0,5,0q�6'    . / � ShowGridLines/ .  $ Arrow��6l    . $	��573��6�   $��62��6�   $��Disabled=�6�    .   5J      �� 5K      $	��563��6'   $��56��66   $
��Auto �6D   �� 5L      $	��563��6'   $��56��66   $
��Auto �6D   �� 5M      $	��563��6'   $��56��66   $
��Auto �6D   �� 5N      $	��563��6'   $��56��66   $
��Auto �6D   �� 5O      $	��563��6'   $��56��66   $
��Auto �6D   �� 5P      $	��563��6'   $��56��66   $
��Auto �6D   �� 5Q      $	��563��6'   $��56��66   $
��Auto �6D   �� 5R      $	��563��6'   $��56��66   $
��Auto �6D   �� 5S      $	��563��6'   $��56��66   $
��Auto �6D   �� 5T      $	��563��6'   $��56��66   $
��Auto �6D   5V      5W      �� 5Y   
   $��2��6   $��30��6(   $��Bottom=�64   $$ 0.5,0.5&�6O   $��0,1,0,0q�6o   ���	#FF2C1D42|�.   .  ��5Z      �� 5[      .R�5\      � $ 
statusGrid��6    5]      �� 5^      $��1* �6/   6<   �� 5_      $��80 �6/   6<   �� 5`      $��1* �6/   6<   5b      5c      .@�5e      �� $��0��6   $��30��6,   $��Center=�68   $
��Left=�6S   .��5f      �� -   5        0 ��Name$0 
StatusLeft��5f       .  Checking for Network Card...6g   5g      �� 5h      $��1��6   $
��Left=�6(   �� 5i      $��1��6   $��right=�6(   �� 5j      $��2��6   $��30��6,   $��Center=�68   $��Right=�6S   .��5k      �� -   5        $0 StatusRight��5k       .  StatusBarItem6Y   5l      5m      �� 5n   
   $��2��6   $��About��6%    . $��270,0,270,5q�6N   $��20��6c   $��Bottom=�6o   $
 Hand��6�   5o      5p      