   M S B A M L   `   `   `  ����F  BUserNewsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:UserNewsApp.ViewModelsUserNewsApp.ViewModels  5      $    UserNewsApp.Views.CategoryPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3vm$clr-namespace:UserNewsApp.ViewModels     5        N� Title$  CategoryPage��5	       � DataContext 5      2   ,UserNewsApp.ViewModels.CategoryPageViewModel  5   
   .��5      � ���	#FF272727 � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      $	��40* �6   �� 5      $	��40* �6   �� 5      $	��40* �6   �� 5      $	��40* �6   �� 5      $	��40* �6   �� 5      $	��40* �6   �� 5      $	��40* �6   �� 5      $	��40* �6   �� 5      $��5* �6    � ColumnDefinitions 5   
   �� 5      $	��15* �6   �� 5      $	��50* �6   �� 5       $	��15* �6   .+�5#   
   �� $	��All��60   ���	#FFFFB582$
��Bold"�6U   $��20(�6g   $��1��6u   $��1��6�   $��5q�6�   ��6   �� *
GetAllNews+6�   �� 5$   
   $��National��65   ���	#FFFFE77D$
��Bold"�6_   $��20(�6q   $��1��6   $��2��6�   $��5q�6�   ��6   �� *GetNationalNews+6�   �� 5%   
   $��World��62   ���	#FFFF8E8E$
��Bold"�6Y   $��20(�6k   $��1��6y   $��3��6�   $��5q�6�   ��6   �� *GetWorldNews+6�   �� 5&   
   $��Sport��62   ���	#FFB6FF8C$
��Bold"�6Y   $��20(�6k   $��1��6y   $��4��6�   $��5q�6�   ��6   �� *GetSportNews+6�   �� 5'   
   $��
Technology��67   ���	#FF8686FF$
��Bold"�6c   $��20(�6u   $��1��6�   $��5��6�   $��5q�6�   ��6   �� *GetTechnologyNews+6�   �� 5(   
   $��Entertainment��6:   ���	#FF84DDFF$
��Bold"�6i   $��20(�6{   $��1��6�   $��6��6�   $��5q�6�   ��6   �� *GetEntertainmentNews+6�   �� 5)   
   $
��Quit��6*   $
��Bold"�69   $��20(�6K   $��1��6Y   $��7��6i   $��5q�6v   ���	#FFA6A6A6��6   �� *Quit+6�   �� 5*   
   $��	Subscribe��6/   $
��Bold"�6C   $��20(�6U   $��1��6c   $��8��6s   $��5q�6�   ���	#FF008700
���������6   �� *	Subscribe+6�   5,      5-      