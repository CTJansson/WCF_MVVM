   M S B A M L   `   `   `  ����F  BUserNewsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:UserNewsApp.ViewModelsUserNewsApp.ViewModels  5      $    UserNewsApp.Views.ReadNewsPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3vm$clr-namespace:UserNewsApp.ViewModels     5        N� Title$  ReadNewsPage��5	       � DataContext 5      2   ,UserNewsApp.ViewModels.ReadNewsPageViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $	��43* �6   �� 5      $��5* �6   .+�5   
   �� $��0��64   $��Stretch=�6A   $��Stretch=�6_   ��6   �� *	NewsPosts+��5      �� 5      .R�5      �� 
���   �$��0,0,0,1q�61   ._�5      �� .+�5      � $	��600��6(   .+�5   "   �� $��14(�6D   $
��Bold"�6R   ��6,   �� *Header+6R   �� 5   "   $
��    ��6,   �� 5   "   $��12(�6G   $��Italic$�6U   $
��Left=�6h   $��Center=�6�   ��6,   �� *	Date.Year+6�   �� 5   "   $��/��6,   $��Center=�65   �� 5   "   $��12(�6H   $��Italic$�6V   $��Center=�6i   $��Center=�6�   ��6,   �� *
Date.Month+6�   �� 5   "   $��/��6,   $��Center=�65   �� 5    "   $��12(�6F   $��Italic$�6T   $��Right=�6g   $��Center=�6�   ��6,   �� *
Date.Day+6�   5!      � 5"      $	��600��6(   .+�5#   "   �� $��12(�6E   $
��Wrap=�6S   ��6,   �� *	Content+6S   5$      �� 5%      $��13(�6C   $��Italic$�6Q   $��0,2,0,0q�6d   ��6(   �� *	WrittenBy+6d   5&      5'      5(      5*      �� 5+   
   $
��Back��68   $��1��6G   $��5q�6T   ��6   �� *BackToPreviousPage+6T   5,      5-      