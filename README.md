# AutoScaleHelper

## 简介

一个适用于Winform的窗体/控件布局缩放自适应辅助类，其前身是Winform.AutoSizeHelper。AutoScaleHelper对其前身进行重构，增加了使用时的灵活性，并提供多种缩放模式，以满足不同的需求任务。  
该辅助类适用于窗体/控件大小被改变后其内部控件需要根据原布局进行缩放自适应的情况。

## 功能

- 支持对winform自带的大多数可视化控件缩放
- 支持对自定义控件的缩放
- 支持动态添加控件并使该控件具有自适应缩放的特性
- 设置缩放区域后，如果想要某些控件不具有缩放特性，可对这些控件单独设置
- 支持多种缩放模式
- 支持字体自适应（根据其所属控件进行自适应）
- 可以设置某些控件的字体变化依赖于某个控件的字体

## 安装
可在Nuget包管理器中搜索AutoScaleHelper进行下载安装。  
Nuget: https://www.nuget.org/packages/AutoScaleHelper

## 基本使用

首先，将窗体的自带缩放模式改为None。具体地，找到该窗体的AutoSacleMode属性，将其改为None。（如果你要缩放的区域(容器)不是窗体但带有autoscalemode属性，最好也改为None）  
![autoscalemode](./img/autoscalemode.jpg)

设置每个直接子控件的anchor属性。如果你不知道anchor属性的作用，在该例子中你可以将每个子控件的anchor设为none或者调用控件的SetAnchorNone扩展方法。具体如何理解和设置anchor请看【锚定位】一节。  

转到该窗体的后台代码部分，编写代码如下图所示：  
![窗体1后台代码](./img/Form1Backend.jpg)  

需要注意的点：  
因为需要缩放的控件不止一个，通常是一个容器（如Panel，GroupBox等）里的大部分子控件都要缩放，所以这里我们把这个容器叫做“缩放区域（容器）”。  
缩放区域（容器）一定要有SizeChanged事件处理程序（在该例子中就是ScaleModeForm1_SizeChanged方法）。  
SetContainer方法用于设置缩放区域。  
SuspendLayout和ResumeLayout方法用于布局刷新，这两个方法会使得窗体缩放时在视觉效果上更加流畅，在控件较多时尤为明显，若要使用，这两个方法必须成对出现。  

## 缩放模式

目前有三种缩放模式，分别是根据容器比例缩放，保持自身比例并根据容器水平缩放比缩放和保持自身比例并根据容器垂直缩放比缩放。

### 根据容器比例缩放

当容器发生大小变化时，变化后的宽度与变化前的宽度有一个缩放的比例wRate，对高度来说同理hRate。容器内部的直接子控件，其宽度会根据wRate进行缩放，其高度会根据hRate进行缩放，子控件缩放后的宽度和高度之间的比例不一定与缩放前的比例相等，它的宽度和高度只受容器的wRate和hRate的影响。其具体效果如下图所示：  
![缩放模式1](./img/缩放模式1.gif)

该模式也是默认的缩放模式。

### 保持自身比例并根据容器水平缩放比缩放  

有时候，我们需要在缩放时保持控件自身的宽高比，并且只有当容器的宽度发生变化时，控件才需要进行缩放，那么就是这个模式。其具体效果如下图所示：  
![缩放模式2](./img/缩放模式2.gif)

### 保持自身比例并根据容器垂直缩放比缩放  

该模式与保持自身比例并根据容器水平缩放比缩放类似，只不过，只有在拖动窗体高度时，控件才会缩放，缩放时同样保持自身宽高比。因为与上一个模式类似，这里不再放置gif。

## 锚定位

每个可视化控件都有Anchor属性，这个属性被翻译为锚，它的作用是基于父容器的定位。当一个控件的设置anchor为left时，该控件的左边到其父容器的左边的距离保持固定；同理，设置为right就表示该控件的右边到父容器的右边的距离保持固定。如果同时设置了left和right，那么左边距离和右边距离都会被固定，控件的宽度会因此而被拉伸。  
**锚定位对缩放后的位置有影响。**  
举个例子，在窗体右下角放置一个按钮，我们想要的效果是，按钮被缩放后，其右侧依旧紧贴窗体工作区的右边界，其底部依旧紧贴窗体工作区的底部。  
如果我们不对该按钮的anchor进行设置，保持其默认的left+top，那么它的效果是这样的：  
![错误锚定位](./img/锚定位1.gif)  
这是因为left会让该控件的左边到窗体的左边界的距离保持不变，top会让控件顶部到窗体的上边界的距离保持不变。  
接着，我们把该控件的anchor设置为bottom+right，看看是不是控件就紧贴窗体右边界和下边界了。  
![正确锚定位](./img/缩放模式1.gif)

## 设置字体自适应

通过设置AutoScale的AutoFont为True即可。  
如果你的需求是只需要字体自适应，可以使用TextScale而不是AutoScale类。

## 设置某个控件不缩放

不缩放有三种模式，分别是自身不缩放和内部控件不缩放。设置不缩放的控件必须在缩放范围内才有效。    
- 自身不缩放：即控件自身不受缩放区域影响，保持原始位置，大小和字体。
- 内部控件不缩放：即控件的内部子控件不缩放，但该控件缩放，也就是说，该控件的位置，大小依然受缩放区域影响，但其内部的子控件不会缩放，且字体不会改变。  
- 字体不缩放：即该控件的字体不缩放。

## 字体依赖

所谓字体依赖，就是可以设置某些控件的字体变化依赖于某个控件的字体。例如，现在有一个textbox和label，我们希望
在label的字体放大时，textbox的字体也跟随着Label的字体放大，那么可以让textbox的字体依赖于label。具体到代码上就是：

```
autoScale.FontDependOn(textBox1, label1);
```

## Q&A

Q：该类库可以实现窗体分辨率自适应吗？  
A：可以借助该类库实现。首先要明确一点，AutoScaleHelper主要解决窗体在大小改变时，如何让内部控件自适应布局的问题，
但窗体本身大小如何适应当前屏幕分辨率，该类库并没有针对这个问题的类或者方法，开发者需要自己去做这个事情。  

Q：窗体大小改变时，label好像没有缩放？  
A：如果label的AutoSize属性设置为True的话，其大小会自适应内容大小，因此即使其容器布局在缩放，也不影响其大小。
要想label的大小也发生变化，请把AutoSize改为false。  

Q：窗体大小改变时，两个紧挨着的label会出现遮挡现象，怎么解决？  
A：使用TableLayoutPanel来包裹这两个label，网格布局设置为一行两列，将两个label分别放入
第一列和第二列，并设置它们的anchor使得它们向网格布局的列中间靠拢，
详情可参考Demo项目中的Demo._7_常用控件测试.Form_Textbox窗体中的例子。  

Q：窗体大小改变时，如何让TextBox(单行)也随着缩放？  
A：TextBox有一个特点是，它的高度只能通过设置字体大小来改变，具有此特点的控件还有ComboBox，NumbericUpDown等。
因为高度无法主动改变，所以AutoScale的AutoFont属性对其也不会生效（AutoFont的字体缩放是根据文本所在控件的高度缩放比例进行缩放的），
因此本人另辟蹊径，让TextBox这类控件的字体大小变化依赖于某个其他控件（也就是前面所说的字体依赖），这个“其他控件”必须是在缩放容器里的。
详情可参考Demo项目中的Demo._7_常用控件测试.Form_Textbox窗体中的例子。 

Q：为什么自定义控件内部不会缩放？  
A：AutoScale类在缩放控件大小时，如果遇到的是自定义控件内部的控件，则不会处理。
原则上，自定义控件内部的子控件应该如何自适应布局缩放，是该控件开发者要解决的问题，
而不应该让自适应布局帮助类来解决。    
你可以给自定义控件挂载一个AutoScale实例，使得其具有自适应布局的特性，
详情可参考Demo._5_自定义控件的缩放.UserControlForm1和UserControlForm2。  

Q：SetAnchorNone会把一个控件里的所有控件anchor设置为空，但我想保留其中的一些子控件的anchor  
A：调用SetAnchorNoneExcept方法  

Q：该类库报错：存在name重复的容器类控件(如Panel,GroupBox,TabControl或ContainerControl),name=XXX...，该如何解决？  
A：以下情况有可能造成该报错：  
1. 在调用SetContainer前动态添加了name相同的多个容器类控件。解决方法：动态添加时，设置每个容器的name不相同。
2. 添加了某些自定义控件（但不继承自UserControl），该自定义控件内部具有多个相同name的容器类控件。
解决方法：如果该自定义控件来自第三方类库，可以再寻找其他类库的替代控件；如果是自己写的控件，请保证内部的每个容器类控件的name不相同。

Q：该类库报错：出现该错误有可能是在调用SetContainer后，缩放区域内部动态添加或删除了容器类的控件...，该如何解决？  
A：以下情况有可能造成该报错：  
1. 在调用SetContainer后，缩放区域内部动态添加或删除了容器类的控件（如panel,ContainerControl,GroupBox,TabControl）。解决方法是，
在动态添加或删除控件后需要调用AutoScale的AddControl或RemoveControl方法。
详情可参考Demo._4_动态添加控件.DynaAddCtrlForm1中的代码。  
2. 在调用SetContainer后，某个控件的Parent属性被代码执行修改，这种情况请
设置这个控件的父容器为不缩放。

Q：我只想缩放指定控件内部的直接子控件布局，但不想影响子控件的子控件布局  
A：调用UpdateControlsLayout时传入false参数  

Q：ToolStrip内部控件没有缩放？  
A：是的，因为ToolStrip内部控件缩放比较难处理，因此AutoScale类不处理它，类似的还有Form类。
另外，AutoScale在处理一些控件时会缩放其自身大小，但不会缩放其内部的控件的大小和位置，如
DataGridView，UpDownBase。

有其他问题或者bug请提issue，并附上代码或图片。

## 其他

更多例子请clone仓库中的Demo项目学习和借鉴。如果您觉得该项目对您有帮助，请留下您的star谢谢~

## 更新

### 1.0.5更新  
不好意思非常抱歉，在1.0.3版本中又测试出一个严重错误（该错误导致AutoScale的AddControl方法报错），因此更新至1.0.5版本（之所以没有1.0.4是因为4是一个不吉利的数字），请各位见谅！

### 1.0.3更新  
不好意思非常抱歉，由于在1.0.2版本中存在一个低级错误，该错误可能导致一些严重问题，因此更新到1.0.3版本，请各位见谅！

### 1.0.2更新

- 增加解除字体依赖方法，以避免动态删除字体依赖相关的控件时导致报错的问题
- 新增TextScale类。考虑到这种情况：界面已经做了缩放自适应（通过网格布局或流式布局），但是字体没有做自适应处理。
此时可以使用TextScale来单独对文本进行一个大小的自适应
- AutoScale的UpdateControlsLayout方法新增一个传入参数recursive，该参数设置是否对每个层次进行缩放
- 控件扩展方法新增SetAnchorNoneExcept，该方法可以在设置子控件anchor为None时，控制某些子控件的anchor保持之前的设置不变

### 1.0.1更新

- 不缩放模式添加不缩放字体类型，设置后该控件字体不缩放
- 动态添加自定义控件时可以挂载一个AutoScale并对其进行操作，这样做是为了不破坏自定义控件的内部代码而又能给控件实例添加缩放自适应的功能。
- 去除字体依赖只在AutoFont模式下生效的限制