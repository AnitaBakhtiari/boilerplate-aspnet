﻿using DataCore.Tasks.Interface;

namespace DataCore.Tasks;

public abstract class RepositoryTask8<TRepository, TOutput, TInput1, TInput2, TInput3, TInput4, TInput5, TInput6,
    TInput7, TInput8> : BaseRepositoryTask<TRepository, TOutput>,
    IRepositoryTask8<TRepository, TOutput, TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TInput7, TInput8>
{
    public abstract TOutput Execute(TInput1 t1, TInput2 t2, TInput3 t3, TInput4 t4, TInput5 t5, TInput6 t6, TInput7 t7,
        TInput8 t8);
}