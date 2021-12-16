RequestHandlerBase -> Flyweight that store intrinsict state - TReq, TRes types
ContextualObject -> store the extrinsic state along with reference to the flyweight object

Keep in mind that we don't actually need a contextual object in this example. The lifetime of the ContextualObjects is limited to the `Send` function scope. Please see `SendOptimized` for more details
