﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Hittable {

    void Hit(Projectile hitter);
}
