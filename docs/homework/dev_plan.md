---
title: 软件开发计划书

toc: true
toc-title: 目录
toc-depth: 2
numbersections: true

lang: zh-CN

fontsize: 11pt
linestretch: 1.05

linkcolor: blue

documentclass: scrartcl 

mainfont: Tinos
mainfontoptions:
  - BoldFont=Tinos Bold
  - ItalicFont=Tinos Italic
  - BoldItalicFont=Tinos Bold Italic
CJKmainfont: Source Han Serif CN
CJKmainfontoptions:
  - BoldFont=Source Han Serif CN Bold
  - ItalicFont=Source Han Serif CN Italic
  - BoldItalicFont=Source Han Serif CN Bold Italic
monofont: Iosevka
monofontoptions:
  - BoldFont=Iosevka Bold
  - ItalicFont=Iosevka Italic
  - BoldItalicFont=Iosevka Bold Italic
CJKmonofont: Source Han Sans SC
CJKmonofontoptions:
  - BoldFont=Source Han Sans SC Bold
  - ItalicFont=Source Han Sans SC Italic
  - BoldItalicFont=Source Han Sans SC Bold Italic

header-includes:
  - \usepackage{xeCJK}
  - \XeTeXlinebreaklocale "zh"
  - \XeTeXlinebreakskip = 0pt plus 1pt minus 0.1pt
---

<!-- [TOC] -->

# 引言

## 目的

<!-- 不想说空话，就这样了吧 -->

编写此计划的目的是为了合理安排组织成员，有效利用时间，以确保项目进度，预见项目风险等活动。使项目严格按照软件开发流程进行，遵循正规的顺序开展。同时，项目开发人员通过此计划书明确项目目标和各自职责。它说明软件的开发方法、制定计划，以指导工作用。

本计划书主要确定：

- 软件开发的内容、生命周期；
- 软件规范、方法和标准；
- 工作规模、工作量和成本的估计；
- 开发进度的制定；
- 风险的估计。

## 范围

软件开发计划书包括：

- 软件规模估计
- 软件模块规划
- 进度安排
- 质量保证计划

## 定义

- N/A: Not Applicable，无、不适用
- 玩家: 指游玩此游戏的人
- 系统/程序: 指游戏本身
- Unity: [Unity3D][unity] 游戏引擎

[unity]: https://unity.com

## 参考资料

1. Unity Scripting Reference (<https://docs.unity3d.com/ScriptReference>)
2. Unity Manual (<https://docs.unity3d.com/Manual>)
3. Microsoft Docs (<https://docs.microsoft.com/zh-cn/>)


## 相关文档

1. 开发需求说明书 (<https://github.com/01010101lzy/software-engineering-simulator/blob/master/docs/homework/spec.md>)

## 版本历史

见本文件在 GitHub 的[版本历史][git_history]。

[git_history]: https://github.com/01010101lzy/software-engineering-simulator/commits/master/docs/homework/dev_plan.md

# 项目概述

软件工程模拟器（Software Engineering Simulator, 缩写为 SESim）是一款模拟软件开发过程的游戏。

**开发工具:** Unity3D  
**开发语言:** C#  
**开发周期:** 45 天

## 项目范围

### 主要功能点

- 游戏配置文件的读取
- 游戏存档的读取与存储
- 游戏内部运行机制，包括：
  - 资源随时间的变化
  - 虚拟开发人员的开发效率的计算
  - 虚拟项目的进度计算
  - 游戏事件的计算
- 游戏图形界面的设计与应用

### 主要性能点

由于本程序是一个游戏，每一帧的更新操作都需要在至多 1/30 s 内计算完成。

### 主要接口

- （后期）面向高级玩家的插件和 Mod（模组）系统

## 目标用户

本游戏的目标用户是普通及偏硬核的电脑游戏玩家。

# 项目组织

由于涉及到的开发人员较少，本项目的组织比较扁平、松散。其中：

- 项目管理人员将负责项目整体结构的设计、功能点的选取等工作；
- 软件开发人员将负责从代码编写、功能测试、游戏内部功能组合等全部工作；
- 美术工作人员将负责图形界面的设计、建模等工作；
- 音乐工作人员将负责游戏的配乐等工作。

人员与职务的安排如下表（暂定，使用 GitHub 用户名以方便追踪）：

| 人员            | 职务             |
|-----------------|------------------|
| @01010101lzy    | 管理、软件、美术 |
| @awesomeztl     | 软件             |
| @y199387        | 软件             |
| @Maplecr        | 软件             |
| @MoonLight23333 | 软件             |
| @Dimpurr        | 音乐（外援）     |

: 人员安排表

# 生命周期

本项目采用的是瀑布式模型。此模型的本质是每个阶段的活动只做一次。从上一阶段向下一阶段逐渐过渡，最终得到所要开发的产品。本项目主要分为问题定义、可行性研究、需求分析、总体设计、详细设计、编码和单元测试、综合测试等多个阶段。

# 规范、方法与标准

## 代码要求

### 格式

所有 C# 代码的编写需要遵循 [微软官方文档中推荐的格式][cs_coding_convensions] 编写。所有注释和提交说明（commit message）需尽量使用英语编写。

请尽量选用合适、简明的命名空间。项目的根命名空间是 `Sesim`。

请善用 `#region` 分割代码区域。

[cs_coding_convensions]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions

### 路径

所有的程序代码请尽量放在 `Assets/lib` 内部。测试代码请放在 `Assets/test` 内部。

# 任务与工作产品

| 任务     | 工作产品                       | 交付时间  |
|----------|--------------------------------|-----------|
| 需求分析 | 需求分析说明书、规格分析说明书 | 2019/4/28 |
| 系统设计 | 系统设计说明书                 | 2019/5/19 |
| 系统实现 | 源代码                         | 2019/6/2  |
| 测试     | 各种测试报告                   | 2019/6/2  |
| 产品交付 | 用户手册                       | 2019/6/2  |
| 产品维护 | 软件问题维护记录               | 2019/6/2  |

 

# 成本估计

由于开发工作是课程作业，没有人工费用。其余内容的费用待补充。

# 关键计算机资源计划

具体需求见[项目 Readme 文件][readme]。简要说明如下：

## 开发

- 性能高于 Intel i5-6300U 的 CPU
- 大于 8 GiB 的内存
- 至少 5 GiB 硬盘空间
- Unity Editor 2018.3.12f1
- Microsoft .NET Framework 4.7.1
- Nuget

## 运行（预计）

- 性能高于 Intel i5-6200U 的 CPU
- 大于 2 GiB 的内存
- 至少 1 GiB 硬盘空间

[readme]: https://github.com/01010101lzy/software-engineering-simulator/blob/master/readme.md

# 软件项目进度计划

![](assets/gantt.png)

<!-- Gantt 图原始代码 (mermaidjs):

```mermaid
gantt
    dateformat YYYY-MM-DD
    section 需求分析
    行为需求分析            : done, a1, 2019-04-08, 1d
    确定选题                : done, a2, after a1, 2d
    确定编程语言和工具      : done, a3, after a2, 1d
    指定交付期限            : done, a4, after a3, 1d

    section 系统设计
    初步计划                : done, b1, 2019-04-15, 1d
    制定功能规范            : active, b2, after b1, 10d
    开发原型                : active, b3, after b1, 10d
    审核规范                : active, b4, after b2, 1d

    section 编码
    确定模块划分            : active, c1, after b4, 3d
    指派任务                : c2, 2d after b2, 2d
    编写代码                : c3, after c2, 2019-05-26

    section 测试
    单元测试                : d1, 2019-05-01, 2019-05-26
    集成测试                : d2, 2019-05-05, 2019-06-03
``` -->

# 风险分析

目前本项目可能发生的将会对项目按预期时间、资源和预算完成产生重大影响的事件包括以下几点：

- 易发生重大风险事件的高风险区域：用户需求、设计、测试、运行平台等。
- 小组成员或因不可抗力无法准时准确完成任务。

拟采取的预防措施：增加投入、纠错、协作完成等。

风险事件发生后建议采用的处理措施：更改计划、降低难度系数等。

# 设备工具计划

目前需要的设备为工程小组各位成员的电脑和云平台。

# 项目评审

校历第十四周即6月2日前提交源代码，可执行程序等内容。

# 度量

项目由管理人员每周对所有数据进行统计和记录，每天（自动化）运行测试记录测试数据。需要度量的数据包括：

- 项目各个功能的实现情况（整体完成度）；
- 单元测试和集成测试的覆盖率和错误数量；
- 项目中各类任务耗时；
